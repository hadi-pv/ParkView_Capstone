namespace ParkView_Capstone.Models.Room
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public decimal RoomPrice { get; set; }
        public int RoomQuantity { get; set; }
        public string RoomLocation { get; set; }
        public int MaxAdult { get; set; }
        public int MaxChildren { get; set; }
        public int MaxPeople { get; set; }
    }
}
