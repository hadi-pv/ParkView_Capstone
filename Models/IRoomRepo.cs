using ParkView_Capstone.Models.Room;

namespace ParkView_Capstone.Models
{
    public interface IRoomRepo
    {
        public IEnumerable<RoomType> GetAllRoomTypes { get; }
        public IEnumerable<RoomLocked> GetAllRoomLocked { get; }
        public IEnumerable<RoomOccupied> GetAllRoomOccupied { get; }

        public IEnumerable<RoomType> 
            GetAllAvailableRooms(string location,DateOnly CheckIn,DateOnly CheckOut,int AdultNo,int ChildrenNo);

        public void LockRoom(RoomType roomType);
        public int IsRoomLocked(RoomType roomType);
        public int IsRoomOccupied(RoomType roomType);
    }
}
