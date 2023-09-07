using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkView_Capstone.Migrations;
using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Servicess;

namespace ParkView_Capstone.Models
{
    public class ServiceDbRepo : IServiceRepo
    {
        ParkViewDbContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;
        public IServiceProvider ServiceProvider;

        public ServiceDbRepo(ParkViewDbContext parkViewDbContext,UserManager<IdentityUser> userManager,IServiceProvider serviceProvider)
        {
            _dbcontext = parkViewDbContext;
            _userManager = userManager;
            ServiceProvider = serviceProvider;
        }
        public IEnumerable<Services> GetAllServices => _dbcontext.Services;

        public void AddBookingServices(BookingServiceDetails bookingServiceDetails)
        {
            ISession session = ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            bookingServiceDetails.UserId = _userManager.GetUserId(ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.User);
            bookingServiceDetails.BookingCartId = session.GetString("CartId");
            _dbcontext.BookingServiceDetails.Add(bookingServiceDetails);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<BookingServiceDetails> GetCartServiceItems()
        {
            ISession session = ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var bookingcartid= session.GetString("CartId");
            return _dbcontext.BookingServiceDetails.Where(b => b.BookingCartId == bookingcartid).Include(s=>s.Service);
        }

        public IEnumerable<BookingServiceDetails> GetPrevServices(string userid)
        {
            return _dbcontext.BookedServices.Include(s=>s.BookingServiceDetails).Include(s=>s.BookingServiceDetails.Service).Where(s => s.UserId == userid).Select(b => b.BookingServiceDetails);
        }

        public void DeleteService(int serviceid)
        {

        }
    }
}
