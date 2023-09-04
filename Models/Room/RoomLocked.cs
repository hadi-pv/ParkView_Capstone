namespace ParkView_Capstone.Models.Room
{
    public class RoomLocked
    {
        public int RoomLockedId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomQuantity { get; set; }
        public DateOnly RoomCheckIn { get; set; }
        public DateOnly RoomCheckOut { get; set; }

        public RoomType RoomType { get; set; }
    }
}
