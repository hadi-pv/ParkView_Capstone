using Microsoft.AspNetCore.Identity;
using ParkView_Capstone.Models.Bookings;

namespace ParkView_Capstone.Models.Rooms
{
    public class RoomOccupied
    {
        public int RoomOccupiedId { get; set; }
        public int RoomId { get; set; }
        public int RoomQuantity { get; set; }
        public int BookingRoomDetailsId { get; set; }
        public DateOnly RoomCheckIn { get; set; }
        public DateOnly RoomCheckOut { get; set; }
        public int UserId { get; set; }
        public bool IsCancelled { get; set; }

        public IdentityUser User { get; set; }
        public Room Room { get; set; }
    }
}
