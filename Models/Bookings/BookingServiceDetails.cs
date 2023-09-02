using ParkView_Capstone.Models.Room;
using ParkView_Capstone.Models.Services;

namespace ParkView_Capstone.Models.Bookings
{
    public class BookingServiceDetails
    {
        public int BookingServiceDetailsId { get; set; }
        public int BookingId { get; set; }
        public int ServiceId { get; set; }
        public int ServiceQuantity { get; set; }
        public decimal ServicePriceAmount { get; set; }

        public Booking Booking { get; set; }
        public Service Service{ get; set; }
    }
}
