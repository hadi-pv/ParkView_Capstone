using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Bookings;
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

        [Authorize]
        public RedirectToActionResult AddBookingServices(int serviceid)
        {
            var services = _servRepo.GetAllServices.SingleOrDefault(s=>s.ServiceId == serviceid);
            BookingServiceDetails bookingServiceDetails = new BookingServiceDetails()
            {
                ServiceId = serviceid,
                ServiceQuantity = 1,
                ServicePriceAmount = services.ServicePrice
            };
            _servRepo.AddBookingServices(bookingServiceDetails);
            return RedirectToAction("Index");
        }
    }
}
