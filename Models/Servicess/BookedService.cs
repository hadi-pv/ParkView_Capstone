using ParkView_Capstone.Models.Bookings;

namespace ParkView_Capstone.Models.Servicess
{
    public class BookedService
    {
        public int BookedServiceId { get; set; }
        public int BookedServiceDetailsId { get; set; }
        public string UserId { get; set; }

        public BookingServiceDetails? BookingServiceDetails { get; set; }
    }
}
