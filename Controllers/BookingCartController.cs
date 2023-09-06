using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Rooms;
using ParkView_Capstone.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ParkView_Capstone.Controllers
{
    [Authorize]
    public class BookingCartController : Controller
    {
        private readonly IRoomRepo _roomRepo;
        private readonly BookingCart _bookingCart;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ParkViewDbContext _dbcontext;

        public BookingCartController(IRoomRepo roomRepo, BookingCart bookingCart,UserManager<IdentityUser> userManager,ParkViewDbContext parkViewDbContext)
        {
            _roomRepo = roomRepo;
            _bookingCart = bookingCart;
            _userManager = userManager;
            _dbcontext = parkViewDbContext;
        }

        public IActionResult Index()
        {
            var items = _bookingCart.GetBookingCartItems();
            _bookingCart.BookingCartItems = items;

            var bookingcartviewmodel = new BookingCartViewModel()
            {
                bookingCart = items
            };

            return View(bookingcartviewmodel);
        }


        public RedirectToActionResult AddRoomQuantity(int bookingdetailsid,int quantity)
        {
            var bookingcartitem = _bookingCart.GetBookingCartItems().SingleOrDefault(m => m.BookingCartItemId == bookingdetailsid);
            if (quantity == 0)
            {
                _bookingCart.RemoveFromCart(bookingcartitem);
            }
            else
            {
                bookingcartitem.BookingRoomDetails.RoomQuantity = quantity;
            }
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult AddToBookingCart(BookingRoomDetails bookingRoomDetails)
        {
            Console.WriteLine(ModelState);
            if(ModelState.IsValid)
            {
                Room room = _roomRepo.GetAllRooms.First(r => r.RoomId == bookingRoomDetails.RoomId);
                Console.WriteLine(bookingRoomDetails.CheckInDate);

                var selectedroom = new BookingRoomDetails()
                {
                    RoomId = bookingRoomDetails.RoomId,
                    Room = room,
                    RoomQuantity = bookingRoomDetails.RoomQuantity,
                    RoomPrice = room.RoomPrice,
                    AdultNo = bookingRoomDetails.AdultNo,
                    ChildrenNo = bookingRoomDetails.ChildrenNo,
                    CheckInDate = DateOnly.ParseExact(bookingRoomDetails.CheckInDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null),
                    CheckOutDate = DateOnly.ParseExact(bookingRoomDetails.CheckOutDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", null),
                    BookedDate = new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day),
                    UserId = _userManager.GetUserId(HttpContext.User)
                };
                _bookingCart.AddToBookingCart(selectedroom);
            }
            else
            {
                Console.WriteLine("Error in AddToBookingCart");
            }

            return RedirectToAction("Index");
        }


        public IActionResult CompleteBooking(decimal total)
        {
            var bookingcartitems=_bookingCart.GetBookingCartItems();
            if (bookingcartitems == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _bookingCart.CompleteBooking(bookingcartitems);
                decimal gstamt=0;
                foreach (var item in bookingcartitems)
                {
                    gstamt = item.RoomPriceFee * item.BookingRoomDetails.Room.RoomType.RoomGst;
                }
                CheckOut checkOut = new CheckOut()
                {
                    BookingCartId = bookingcartitems.First().BookingCartId,
                    Items = bookingcartitems,
                    BookedDate = new DateOnly(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day),
                    Total = total+gstamt,
                    User = _dbcontext.Users.SingleOrDefault(s=>s.Id==bookingcartitems.First().UserId)
                };
                return View(checkOut);
            }
        }
            
    }
}
