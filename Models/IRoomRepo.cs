using Microsoft.EntityFrameworkCore;
using ParkView_Capstone.Models.Facilities;
using ParkView_Capstone.Models.Rooms;
using ParkView_Capstone.Models.Hotels;

namespace ParkView_Capstone.Models
{
    public interface IRoomRepo
    {
        public IEnumerable<Room> GetAllRooms { get; }
        public IEnumerable<RoomType> GetAllRoomTypes { get; }

        public IEnumerable<Hotel> GetAllHotels { get; }
        public IEnumerable<RoomLocked> GetAllRoomLocked { get; }
        public IEnumerable<RoomOccupied> GetAllRoomOccupied { get; }

        public IEnumerable<Room> 
            GetAllAvailableRooms(string location,DateOnly CheckIn,DateOnly CheckOut,int AdultNo,int ChildrenNo);

        public int IsRoomLocked(Room roomType, DateOnly CheckIn, DateOnly CheckOut);
        public int IsRoomOccupied(Room roomType, DateOnly CheckIn, DateOnly CheckOut);

        public IEnumerable<FacilityType> GetAllFacilities { get; }
        public IEnumerable<FacilityType> GetAppliedFacilities(int roomtypeid);
    }
}
