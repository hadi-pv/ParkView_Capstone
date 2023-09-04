namespace ParkView_Capstone.Models.Rooms
{
    public class RoomLocked
    {
        public int RoomLockedId { get; set; }
        public int RoomId { get; set; }
        public int RoomQuantity { get; set; }
        public DateOnly RoomCheckIn { get; set; }
        public DateOnly RoomCheckOut { get; set; }

        public Room Room { get; set; }
    }
}
