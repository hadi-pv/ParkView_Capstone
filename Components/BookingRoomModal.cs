using Microsoft.AspNetCore.Mvc;
using ParkView_Capstone.Models.Bookings;

namespace ParkView_Capstone.Components
{
    public class BookingRoomModal:ViewComponent
    {
        public IViewComponentResult Invoke(BookingRoomDetails bookingRoomDetails,int roomid,int reqrooms)
        {
            bookingRoomDetails.RoomId = roomid;
            bookingRoomDetails.RoomQuantity = reqrooms;
            return View(bookingRoomDetails);
        }
    }
}
