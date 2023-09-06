using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Rooms;
using ParkView_Capstone.ViewModels;

namespace ParkView_Capstone.Controllers
{
    public class BookingCartController : Controller
    {
        private readonly IRoomRepo _roomRepo;
        private readonly BookingCart _bookingCart;

        public BookingCartController(IRoomRepo roomRepo, BookingCart bookingCart)
        {
            _roomRepo = roomRepo;
            _bookingCart = bookingCart;
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
                bookingcartitem.BookingRoomDetails.RoomQuantity= quantity;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult AddToBookingCart(BookingRoomDetails bookingRoomDetails)
        {
            Console.WriteLine(ModelState.IsValid);
            if(!ModelState.IsValid)
            {
                Room room = _roomRepo.GetAllRooms.First(r => r.RoomId == bookingRoomDetails.RoomId);
                Console.WriteLine(room.RoomType.RoomName);
                var selectedroom = new BookingRoomDetails()
                {
                    RoomId = bookingRoomDetails.RoomId,
                    Room = room,
                    RoomQuantity = bookingRoomDetails.RoomQuantity,
                    RoomPrice = room.RoomPrice,
                    AdultNo = bookingRoomDetails.AdultNo,
                    ChildrenNo = bookingRoomDetails.ChildrenNo,
                    CheckInDate = new DateOnly(2023, 9, 2),
                    CheckOutDate = new DateOnly(2023, 9, 5)
                };
                _bookingCart.AddToBookingCart(selectedroom);
            }
            else
            {
                Console.WriteLine("Error in AddToBookingCart");
            }

            return RedirectToAction("Index");
        }


        public IActionResult CompleteBooking()
        {
            var bookingcartitems=_bookingCart.GetBookingCartItems();
            if (bookingcartitems == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _bookingCart.CompleteBooking(bookingcartitems);
                return View();
            }
        }
            
    }
}
