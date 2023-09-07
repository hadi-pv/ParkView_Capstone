using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkView_Capstone.Models.Rooms;

namespace ParkView_Capstone.Models.Bookings
{
    public class BookingCart
    {
        public string BookingCartId { get; set; }
        public List<BookingCartItem> BookingCartItems { get; set; }

        public List<BookingServiceItem> BookingServiceItems { get; set; }

       
        public decimal Total { get; set; }
        private readonly ParkViewDbContext _dbcontext;
        public IServiceProvider serviceProvider { get; set; }
        private readonly IdentityUser _userManager;

        public BookingCart(ParkViewDbContext dbcontext, IServiceProvider serviceProvider, IdentityUser userManager)
        {
            _dbcontext = dbcontext;
            this.serviceProvider = serviceProvider;
            _userManager = userManager;
        }

        public static BookingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var context = services.GetService<ParkViewDbContext>();
            var user=services.GetService<IdentityUser>();
            string cartid = session.GetString("CartId");
            if (cartid == null)
            {
                cartid = Guid.NewGuid().ToString();
                session.SetString("CartId", cartid);
            }
            return new BookingCart(context,services,user) { BookingCartId = cartid };
        }

        public void AddToBookingCart(BookingRoomDetails roomDetails)
        {
            var brdetails = _dbcontext.BookingCartItems.Include(b=>b.BookingRoomDetails).SingleOrDefault(
                b => b.BookingRoomDetails.RoomId == roomDetails.RoomId &&
                b.BookingCartId == BookingCartId);

            if (brdetails == null)
            {
                brdetails = new BookingCartItem()
                {
                    BookingCartId = BookingCartId,
                    BookingRoomDetailsId = roomDetails.BookingRoomDetailsId,
                    BookingRoomDetails = roomDetails,
                    BookedDate = new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day),
                    RoomPriceFee = roomDetails.RoomPriceAmount * DaysDifferenceDateOnlyConverted(roomDetails.CheckOutDate,roomDetails.CheckInDate),
                    UserId = roomDetails.UserId
                };
                _dbcontext.BookingCartItems.Add(brdetails);
            }
            else
            {
                brdetails.BookingRoomDetails=roomDetails;
            }
            _dbcontext.SaveChanges();
        }

        public void AddServicesToBookingCart(BookingServiceDetails serviceDetails)
        {
            var brdetails = _dbcontext.BookingServiceItem.Include(b => b.BookingServiceDetails).SingleOrDefault(
                b => b.BookingServiceDetails.ServiceId == serviceDetails.ServiceId &&
                b.BookingCartId == BookingCartId);

            if (brdetails == null)
            {
                brdetails = new BookingServiceItem()
                {
                    BookingCartId = BookingCartId,
                    BookingServiceDetailsId = serviceDetails.BookingServiceDetailsId,
                    BookingServiceDetails = serviceDetails,
                    BookedDate = new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day),
                    SericePriceFee = serviceDetails.ServicePriceAmount,
                    UserId = serviceDetails.UserId
                };
                _dbcontext.BookingServiceItem.Add(brdetails);
            }
            else
            {
                brdetails.BookingServiceDetails = serviceDetails;
            }
            _dbcontext.SaveChanges();
        }


        public void RemoveFromCart(BookingCartItem bcitem)
        {
            if (bcitem.BookingRoomDetails.RoomQuantity > 1)
            {
                bcitem.BookingRoomDetails.RoomQuantity--;
            }
            else
            {
                _dbcontext.Remove(bcitem);
            }
            _dbcontext.SaveChanges();
        }

        public List<BookingCartItem> GetBookingCartItems()
        {
            return BookingCartItems ??
                (BookingCartItems = _dbcontext.BookingCartItems
                .Where(c => c.BookingCartId == BookingCartId)
                .Include(s => s.BookingRoomDetails).Include(s=>s.BookingRoomDetails.Room)
                .Include(s => s.BookingRoomDetails.Room.RoomType).Include(s => s.BookingRoomDetails.Room.Hotel)
                .ToList());
        }

        public List<BookingServiceItem> GetBookingServiceItems()
        {
            return BookingServiceItems ??
                (BookingServiceItems = _dbcontext.BookingServiceItem
                .Where(c => c.BookingCartId == BookingCartId)
                .Include(s => s.BookingServiceDetails).Include(s => s.BookingServiceDetails.Service)
                .ToList());
        }

        public void CompleteBooking(IEnumerable<BookingCartItem> bookingCartItems)
        {
            foreach(BookingCartItem bookingCartItem in bookingCartItems)
            {
                _dbcontext.RoomOccupied.Add(new RoomOccupied()
                {
                    RoomId = bookingCartItem.BookingRoomDetails.RoomId,
                    RoomCheckIn = bookingCartItem.BookingRoomDetails.CheckInDate,
                    RoomCheckOut = bookingCartItem.BookingRoomDetails.CheckOutDate,
                    RoomQuantity = bookingCartItem.BookingRoomDetails.RoomQuantity,
                    BookingRoomDetailsId = bookingCartItem.BookingRoomDetailsId,
                    IsCancelled =false,
                    Room = bookingCartItem.BookingRoomDetails.Room,
                    UserId = bookingCartItem.BookingRoomDetails.UserId
                });
            }
            _dbcontext.SaveChanges();
            deleteSession();
        }

        public Dictionary<string,List<BookingCartItem>> GetAllPrevorders(string userid)
        {
            List<int> bookedrooms = _dbcontext.RoomOccupied.Where(r => r.UserId == userid).Select(r => r.BookingRoomDetailsId).ToList();
            List<BookingRoomDetails> bookingRoomDetails = _dbcontext.BookingRoomDetails.Where(b => bookedrooms.Contains(b.BookingRoomDetailsId)).ToList();
            Dictionary<string, List<BookingCartItem>> result=new Dictionary<string, List<BookingCartItem>>();
            foreach(BookingRoomDetails item in bookingRoomDetails)
            {
                if (!result.Keys.Any(k => k == item.BookingCartId))
                {
                    result[item.BookingCartId] = new List<BookingCartItem>()
                    {
                        _dbcontext.BookingCartItems.Include(b=>b.BookingRoomDetails).Include(b=>b.BookingRoomDetails.Room).Include(b=>b.BookingRoomDetails.Room.RoomType).SingleOrDefault(c=>c.BookingRoomDetailsId==item.BookingRoomDetailsId)
                    };
                }
                else
                {
                    result[item.BookingCartId].Add(
                        _dbcontext.BookingCartItems.Include(b => b.BookingRoomDetails).Include(b => b.BookingRoomDetails.Room).Include(b => b.BookingRoomDetails.Room.RoomType).SingleOrDefault(c => c.BookingRoomDetailsId == item.BookingRoomDetailsId)
                        );
                }
            }
            return result;
        }

        public void deleteSession()
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            BookingCartItems = default(List<BookingCartItem>);
            session.Clear();
        }


        private int DaysDifferenceDateOnlyConverted(DateOnly dateOnly1, DateOnly dateOnly2)
        {
            return (new DateTime(dateOnly1.Year, dateOnly1.Month, dateOnly1.Day) - new DateTime(dateOnly2.Year, dateOnly2.Month, dateOnly2.Day)).Days;
        }
    }
}
