using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Room;

namespace ParkView_Capstone.ViewModels
{
    public class RoomsViewModel
    {
        public IEnumerable<RoomType> Rooms { get; set; }
        public Booking Booking { get; set; }

        public RoomsViewModel(IEnumerable<RoomType> rooms,Booking booking) 
        {
            Rooms = rooms;
            Booking = booking;
        }
    }
}
