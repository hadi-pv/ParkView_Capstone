using Microsoft.EntityFrameworkCore;

namespace ParkView_Capstone.Models.Bookings
{
    public class BookingCart
    {
        public string BookingCartId { get; set; }
        public List<BookingCartItem> BookingCartItems { get; set; }
        public decimal Total { get; set; }
        private readonly ParkViewDbContext _dbcontext;

        public BookingCart(ParkViewDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public static BookingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var context = services.GetService<ParkViewDbContext>();
            string cartid = session.GetString("CartId");
            if (cartid == null)
            {
                cartid = Guid.NewGuid().ToString();
                session.SetString("CartId", cartid);
            }
            return new BookingCart(context) { BookingCartId = cartid };
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
                    RoomPriceFee = roomDetails.RoomPriceAmount,
                };
                _dbcontext.BookingCartItems.Add(brdetails);
            }
            else
            {
                brdetails.BookingRoomDetails.RoomQuantity=roomDetails.RoomQuantity;
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
                .ToList());
        }
    }
}
