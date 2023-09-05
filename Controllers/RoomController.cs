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

        public IActionResult Index()
        {
            IEnumerable<Room> rooms = _roomRepo.GetAllAvailableRooms("Chennai", new DateOnly(2023, 9, 4), new DateOnly(2023, 9, 7), 4,2);

            RoomListViewModal roomListViewModal = new RoomListViewModal()
            {
                Rooms = rooms,
                BookingRoomDetails = new BookingRoomDetails()
                {
                    CheckInDate = new DateOnly(2023, 9, 4),
                    CheckOutDate = new DateOnly(2023, 9, 7),
                    AdultNo = 4,
                    ChildrenNo = 2
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
