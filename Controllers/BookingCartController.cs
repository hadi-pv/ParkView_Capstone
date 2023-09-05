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
                    CheckInDate = bookingRoomDetails.CheckInDate,
                    CheckOutDate = bookingRoomDetails.CheckOutDate
                };
                _bookingCart.AddToBookingCart(selectedroom);
            }
            else
            {
                Console.WriteLine("Error in AddToBookingCart");
            }

            return RedirectToAction("Index");
        }
    }
}
