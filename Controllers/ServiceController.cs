using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Rooms;
using ParkView_Capstone.Models.Servicess;

namespace ParkView_Capstone.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepo _servRepo;

        public ServiceController(IServiceRepo servRepo)
        {
            
            _servRepo = servRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Services> servs = _servRepo.GetAllServices;

            return View(servs);
        }
    }
}
