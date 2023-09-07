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
        public string UserId { get; set; }
        public bool IsCancelled { get; set; }
        public string RP_Payment_id { get; set; }
        public string RP_Signature_id { get; set; }

        public Room Room { get; set; }
    }
}
