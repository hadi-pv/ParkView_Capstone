using ParkView_Capstone.Models.Room;

namespace ParkView_Capstone.Models.Bookings
{
    public class BookingRoomDetails
    {
        public int BookingRoomDetailsId { get; set; }
        public int BookingId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomQuantity { get; set; }
        public DateOnly BookingDate { get; set; }
        public decimal RoomPriceAmount { get; set; }

        public Booking Booking { get; set; }
        public RoomType RoomType { get; set; }
    }
}
