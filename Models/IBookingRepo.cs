using ParkView_Capstone.Models.Bookings;

namespace ParkView_Capstone.Models
{
    public interface IBookingRepo
    {
        public IEnumerable<BookingRoomDetails> BookingRoomDetails { get;}
        public void AddBookingRoomDetails(BookingRoomDetails bookingRoomDetails);
        public BookingRoomDetails GetBookingRoomDetails(int bookingroomdetailsid);
    }
}
