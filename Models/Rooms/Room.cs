using ParkView_Capstone.Models.Hotels;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkView_Capstone.Models.Rooms
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }
        public decimal RoomPrice { get; set; }
        public int RoomQuantity { get; set; }

        public RoomType RoomType { get; set; }
        public Hotel Hotel { get; set; }

        [NotMapped]
        public decimal RoomReq { get; set; }
    }
}
