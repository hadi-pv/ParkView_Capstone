using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Room;

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
            IEnumerable<RoomType> rooms = _roomRepo.GetAllAvailableRooms("bangalore", new DateOnly(2023, 9, 4), new DateOnly(2023, 9, 7), 3,1);
            return View(rooms);
        }
    }
}
