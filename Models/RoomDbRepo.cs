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

                if (room.RoomQuantity - IsRoomLocked(room,CheckIn,CheckOut) - IsRoomOccupied(room, CheckIn, CheckOut) >= reqrooms) { room.RoomQuantity= room.RoomQuantity - IsRoomLocked(room, CheckIn, CheckOut) - IsRoomOccupied(room, CheckIn, CheckOut); room.ReqRooms = (int)reqrooms; }
                else rooms = rooms.Where(r => r.RoomTypeId != room.RoomTypeId);
                
            }

            return rooms;
        }

        //Check if it exists
        public int IsRoomLocked(RoomType roomType, DateOnly CheckIn, DateOnly CheckOut)
        {
            if(GetAllRoomLocked.Any(r => r.RoomTypeId == roomType.RoomTypeId))
            {
                var locked = GetAllRoomLocked
                    .Where(r => r.RoomTypeId == roomType.RoomTypeId)
                    .Where(r=>r.RoomCheckIn<=CheckIn && r.RoomCheckOut>CheckIn);
                return locked.Select(r => r.RoomQuantity).Sum();
            }
            else
            {
                return 0;
            }
            
        }

        public int IsRoomOccupied(RoomType roomType,DateOnly CheckIn, DateOnly CheckOut)
        {
            if (GetAllRoomOccupied.Any(r => r.RoomTypeId == roomType.RoomTypeId))
            {
                var occupied = GetAllRoomOccupied
                    .Where(r => r.RoomTypeId == roomType.RoomTypeId)
                    .Where(r => r.RoomCheckIn <= CheckIn && r.RoomCheckOut > CheckIn);
                return occupied.Select(r => r.RoomQuantity).Sum();
            }
            else
            {
                return 0;
            }
        }

        public void LockRoom(RoomType roomType)
        {
            throw new NotImplementedException();
        }
    }
}
