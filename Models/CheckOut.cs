using Microsoft.AspNetCore.Identity;
using ParkView_Capstone.Models.Bookings;

namespace ParkView_Capstone.Models
{
    public class CheckOut
    {
        public string BookingCartId { get; set; }
        public IEnumerable<BookingCartItem> Items { get; set; }
        public IEnumerable<BookingServiceDetails> Services { get; set; }
        public decimal Total { get; set; }
        public DateOnly BookedDate { get; set; }

        public IdentityUser User { get; set; }
    }
}
