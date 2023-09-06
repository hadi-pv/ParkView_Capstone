using Microsoft.AspNetCore.Identity;

namespace ParkView_Capstone.Models.Bookings
{
    public class BookingCartItem
    {
        public int BookingCartItemId { get; set; }
        public int BookingRoomDetailsId { get; set; }
        public string BookingCartId { get; set; }
        public decimal RoomPriceFee { get; set; }
        public int UserId { get; set; }

        public BookingRoomDetails BookingRoomDetails { get; set; }
        public IdentityUser User { get; set; }
    }
}
