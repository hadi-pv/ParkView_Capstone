using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ParkView_Capstone.Models.Rooms;

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
        public int UserId { get; set; }

        [BindNever]
        public int TotalPeople => AdultNo + ChildrenNo;
        [BindNever]
        public decimal RoomPriceAmount => RoomPrice * RoomQuantity;

        public IdentityUser User { get; set; }
        public Room Room { get; set; }
    }
}
