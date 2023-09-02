using Microsoft.AspNetCore.Identity;

namespace ParkView_Capstone.Models.Bookings
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public string BookingLocation { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal ServicePriceAmount { get; set; }
        public decimal RoomPriceFee { get; set; }

        public IdentityUser User { get; set; }
    }
}
