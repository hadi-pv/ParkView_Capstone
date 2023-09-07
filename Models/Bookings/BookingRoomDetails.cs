using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ParkView_Capstone.Models.Rooms;
using System.ComponentModel.DataAnnotations;

namespace ParkView_Capstone.Models.Bookings
{
    public class BookingRoomDetails
    {
        public int BookingRoomDetailsId { get; set; }
        public int RoomId { get; set; }
        public int RoomQuantity { get; set; }
        public decimal RoomPrice { get; set; }
        public int AdultNo { get; set; }
        public int ChildrenNo { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public DateOnly BookedDate { get; set; }

        [BindNever]
        public string? BookingCartId { get; set; }
        [BindNever]
        public string? UserId { get; set; }
        [BindNever]
        public int TotalPeople => AdultNo + ChildrenNo;
        [BindNever]
        public decimal RoomPriceAmount => RoomPrice * RoomQuantity;
        [BindNever]
        public Room? Room { get; set; }
    }
}
