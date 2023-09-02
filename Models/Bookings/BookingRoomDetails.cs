using ParkView_Capstone.Models.Room;

namespace ParkView_Capstone.Models.Bookings
{
    public class BookingRoomDetails
    {
        public int BookingRoomDetailsId { get; set; }
        public int BookingId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomQuantity { get; set; }
        public DateTime BookingDate { get; set; }
        public int RoomPriceAmount { get; set; }

        public Booking Booking { get; set; }
        public RoomType RoomType { get; set; }
    }
}
