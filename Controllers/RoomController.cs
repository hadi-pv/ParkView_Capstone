using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Rooms;
using ParkView_Capstone.ViewModels;

namespace ParkView_Capstone.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepo _roomRepo;

        public RoomController(IRoomRepo roomRepo) 
        { 
            _roomRepo = roomRepo;
        }

        public IActionResult Index(string location , string checkin,string checkout, int Adults , int Child)
        {
            IEnumerable<Room> rooms = _roomRepo.GetAllAvailableRooms(location, DateOnly.ParseExact(checkin, "yyyy-MM-dd", null), DateOnly.ParseExact(checkout, "yyyy-MM-dd", null), Adults,Child);

            RoomListViewModal roomListViewModal = new RoomListViewModal()
            {
                Rooms = rooms,
                Hotel = _roomRepo.GetAllHotels.SingleOrDefault(h => h.HotelLocation== location),
                BookingRoomDetails = new BookingRoomDetails()
                {
                    CheckInDate = DateOnly.ParseExact(checkin, "yyyy-MM-dd", null),
                    CheckOutDate = DateOnly.ParseExact(checkout, "yyyy-MM-dd", null),
                    AdultNo = Adults,
                    ChildrenNo = Child
                }
            };

            return View(roomListViewModal); 
        }

        public IActionResult SingleRoom(int roomid)
        {
            var room=_roomRepo.GetAllRooms.FirstOrDefault(r=>r.RoomId == roomid);
            var facilities = _roomRepo.GetAppliedFacilities(room.RoomTypeId);

            RoomsViewModel roomsViewModel=new RoomsViewModel(room,facilities);

            return View(roomsViewModel);
        }

        public IActionResult Roomtype()
        {
            IEnumerable<Room> rooms = _roomRepo.GetAllRooms;

            RoomListViewModal roomListViewModal = new RoomListViewModal()
            {
                Rooms = rooms,
                BookingRoomDetails = new BookingRoomDetails()
            };

            return View(roomListViewModal);
        }

        public IActionResult Hoteltype()
        {
            IEnumerable<Room> rooms = _roomRepo.GetAllRooms;

            return View(rooms);
        }


        //public IActionResult BookRoom(int roomId)
        //{
        //    RoomType room = _roomRepo.GetAllRoomTypes.FirstOrDefault(r => r.RoomTypeId == roomId);
        //    BookingRoomDetails roomDetails = new BookingRoomDetails()
        //    {
        //        Booking = booking,
        //        BookingId=booking.BookingId,
        //        RoomTypeId = roomId,
        //        RoomType = room,
        //        BookingDate = DateOnly.FromDateTime(DateTime.Now),
        //        RoomQuantity = (int)room.ReqRooms,
        //        RoomPriceAmount = room.ReqRooms * room.RoomPrice
        //    };
        //    return View(roomDetails);
        //}
    }
}
