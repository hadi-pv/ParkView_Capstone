using ParkView_Capstone.Models.Bookings;
using ParkView_Capstone.Models.Facilities;
using ParkView_Capstone.Models.Rooms;

namespace ParkView_Capstone.ViewModels
{
    public class RoomsViewModel
    {
        public Room Room { get; set; }
        public IEnumerable<FacilityType> Facilities { get; set; }

        public RoomsViewModel(Room room,IEnumerable<FacilityType> facilities) 
        {
            Room = room;
            Facilities = facilities;
        }
    }
}
