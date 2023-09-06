using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkView_Capstone.Models.Rooms
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public int MaxAdult { get; set; }
        public int MaxChildren { get; set; }
        public int MaxPeople { get; set; }
        public string RoomTypeImage { get; set; }
        public decimal RoomGst { get; set; }
    }
}
