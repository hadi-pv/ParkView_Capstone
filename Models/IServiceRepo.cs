

using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Servicess;

namespace ParkView_Capstone.Models
{
    public interface IServiceRepo
    {
        public IEnumerable<Services> GetAllServices { get; }
        public void AddBookingServices(BookingServiceDetails bookingServiceDetails);
        public IEnumerable<BookingServiceDetails> GetCartServiceItems();
        public IEnumerable<BookingServiceDetails> GetPrevServices(string userid);
    }
}
