using ParkView_Capstone.Models.Bookings;

namespace ParkView_Capstone.ViewModels
{
    public class BookingCartViewModel
    {
        public List<BookingCartItem> bookingCart { get; set; }
        public List<BookingServiceDetails> servicecart { get; set; }
    }
}
