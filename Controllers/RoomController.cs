using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Room;
using ParkView_Capstone.ViewModels;

namespace ParkView_Capstone.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepo _roomRepo;
        private static Booking booking;

        public RoomController(IRoomRepo roomRepo) 
        { 
            _roomRepo = roomRepo;
        }

        public IActionResult Index()
        {
            booking = new Booking()
            {
                BookingLocation = "bangalore",
                CheckInDate = new DateOnly(2023, 9, 4),
                CheckOutDate = new DateOnly(2023, 9, 7),
                NumberOfAdults = 3,
                NumberOfChildren = 1
            };
            IEnumerable<RoomType> rooms = _roomRepo.GetAllAvailableRooms("bangalore", new DateOnly(2023, 9, 4), new DateOnly(2023, 9, 7), 3,1);
            

            RoomsViewModel roomsViewModel=new RoomsViewModel(rooms, booking);

            return View(rooms);
        }

        public IActionResult BookRoom(int roomId)
        {
            RoomType room = _roomRepo.GetAllRoomTypes.FirstOrDefault(r => r.RoomTypeId == roomId);
            BookingRoomDetails roomDetails = new BookingRoomDetails()
            {
                Booking = booking,
                BookingId=booking.BookingId,
                RoomTypeId = roomId,
                RoomType = room,
                BookingDate = DateOnly.FromDateTime(DateTime.Now),
                RoomQuantity = (int)room.ReqRooms,
                RoomPriceAmount = room.ReqRooms * room.RoomPrice
            };
            return View(roomDetails);
        }
    }
}
