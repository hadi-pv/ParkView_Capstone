namespace ParkView_Capstone.Models.Bookings
{
    public class BookingServiceItem
    {
        public int BookingServiceItemId { get; set; }
        public int BookingServiceDetailsId { get; set; }


        public string BookingCartId { get; set; }
        public decimal SericePriceFee { get; set; }
        public string UserId { get; set; }
        public DateOnly BookedDate { get; set; }

        public BookingServiceDetails BookingServiceDetails { get; set; }
    }
}
