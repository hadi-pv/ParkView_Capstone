using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;

namespace ParkView_Capstone.Controllers
{
    public class BookingController : Controller
    {
        private IRoomRepo roomRepo;

        public BookingController(IRoomRepo roomRepo)
        {
            this.roomRepo = roomRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookRoom(int roomId)
        {
            return View();
        }
    }
}
