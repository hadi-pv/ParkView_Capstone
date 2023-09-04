using ParkView_Capstone.Models.Room;

namespace ParkView_Capstone.Models
{
    public class RoomDbRepo : IRoomRepo
    {
        ParkViewDbContext _dbcontext;

        public RoomDbRepo(ParkViewDbContext parkViewDbContext) 
        {
            _dbcontext = parkViewDbContext;
        }

        public IEnumerable<RoomType> GetAllRoomTypes => _dbcontext.RoomType;

        public IEnumerable<RoomOccupied> GetAllRoomOccupied => _dbcontext.RoomOccupied;

        public IEnumerable<RoomLocked> GetAllRoomLocked => _dbcontext.RoomLocked;

        public IEnumerable<RoomType> 
            GetAllAvailableRooms(string location, DateOnly CheckIn, DateOnly CheckOut, int AdultNo, int ChildrenNo)
        {
            IEnumerable<RoomType> rooms = GetAllRoomTypes
                .Where(r=>r.RoomLocation.ToLower()==location.ToLower());

            foreach(var room in rooms)
            {
                var reqrooms = MathF.Ceiling(MathF.Min(MathF.Max((float)AdultNo / room.MaxAdult, (float)ChildrenNo / room.MaxChildren), (float)(AdultNo + ChildrenNo) / room.MaxPeople));

                if (room.RoomQuantity - IsRoomLocked(room) - IsRoomOccupied(room) >= reqrooms) { room.RoomQuantity = (int)reqrooms;Console.WriteLine("Remaining Rooms : "+Convert.ToString(room.RoomQuantity - IsRoomLocked(room) - IsRoomOccupied(room))); }
                else rooms = rooms.Where(r => r.RoomTypeId != room.RoomTypeId);
                
            }

            return rooms;
        }

        //Check if it exists
        public int IsRoomLocked(RoomType roomType)
        {
            var locked=GetAllRoomLocked.Where(r=> r.RoomTypeId==roomType.RoomTypeId);
            return locked.Select(r => r.RoomQuantity).Sum();
        }

        public int IsRoomOccupied(RoomType roomType)
        {
            var occupied = GetAllRoomOccupied.Where(r => r.RoomTypeId == roomType.RoomTypeId);
            return occupied.Select(r => r.RoomQuantity).Sum();
        }

        public void LockRoom(RoomType roomType)
        {
            throw new NotImplementedException();
        }
    }
}
