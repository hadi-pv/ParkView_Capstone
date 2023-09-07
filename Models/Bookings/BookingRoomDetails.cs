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
        [Required(ErrorMessage ="Please enter adult number")]
        [Range(1, Int32.MaxValue, ErrorMessage ="Enter a number above 1")]
        public int AdultNo { get; set; }
        [Range(0,Int32.MaxValue, ErrorMessage = "Enter a positive number")]
        public int ChildrenNo { get; set; }
        [Required(ErrorMessage = "Please give a Check In date")]
        public DateOnly CheckInDate { get; set; }
        [Required(ErrorMessage = "Please give a Check Out date")]
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
