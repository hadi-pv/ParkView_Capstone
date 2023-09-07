using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Rooms;

namespace ParkView_Capstone.ViewModels
{
    public class RoomListViewModal
    {
        public IEnumerable<Room> Rooms{get; set; }
        public BookingRoomDetails BookingRoomDetails { get; set; }
    }
}
 