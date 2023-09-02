namespace ParkView_Capstone.Models.Room
{
    public class RoomOccupied
    {
        public int RoomOccupiedId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomQuantity { get; set; }

        public RoomType RoomType { get; set; }
    }
}
