using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ParkView_Capstone.Models.Facilities;
using ParkView_Capstone.Models.Hotels;
using ParkView_Capstone.Models.Rooms;

namespace ParkView_Capstone.Models
{
    public class RoomDbRepo : IRoomRepo
    {
        ParkViewDbContext _dbcontext;

        public RoomDbRepo(ParkViewDbContext parkViewDbContext) 
        {
            _dbcontext = parkViewDbContext;
        }

        public static IEnumerable<Room> GlobalRooms { get; set; }

        public IEnumerable<Room> GetAllRooms => _dbcontext.Room.Include(r=>r.RoomType).Include(r=>r.Hotel);

        public IEnumerable<RoomType> GetAllRoomTypes => _dbcontext.RoomType;

       
        public IEnumerable<RoomOccupied> GetAllRoomOccupied => _dbcontext.RoomOccupied;

        public IEnumerable<RoomLocked> GetAllRoomLocked => _dbcontext.RoomLocked;

        public IEnumerable<FacilityType> GetAllFacilities => _dbcontext.FacilityType;

        public IEnumerable<Hotel> GetAllHotels => _dbcontext.Hotel;

        public IEnumerable<Room> 
            GetAllAvailableRooms(string location, DateOnly CheckIn, DateOnly CheckOut, int AdultNo, int ChildrenNo)
        {
            IEnumerable<Room> rooms;
            if (location != null)
            {
                rooms = GetAllRooms
                .Where(r => r.Hotel.HotelLocation.ToLower() == location.ToLower());
            }
            else if(AdultNo==default(int) & location == null)
            {
                rooms = GlobalRooms;
            }
            {
                 rooms = GetAllRooms;
            }

            foreach(var room in rooms)
            {
                var reqrooms = MathF.Ceiling(MathF.Min(MathF.Max((float)AdultNo / room.RoomType.MaxAdult, (float)ChildrenNo / room.RoomType.MaxChildren), (float)(AdultNo + ChildrenNo) / room.RoomType.MaxPeople));

                if (room.RoomQuantity - IsRoomLocked(room,CheckIn,CheckOut) - IsRoomOccupied(room, CheckIn, CheckOut) >= reqrooms) { room.RoomQuantity= room.RoomQuantity - IsRoomLocked(room, CheckIn, CheckOut) - IsRoomOccupied(room, CheckIn, CheckOut); room.RoomReq = (int)reqrooms; }
                else rooms = rooms.Where(r => r.RoomTypeId != room.RoomTypeId);
                
            }

            GlobalRooms = rooms;

            return rooms;
        }

      
        //Check if it exists
        public int IsRoomLocked(Room room, DateOnly CheckIn, DateOnly CheckOut)
        {
            if(GetAllRoomLocked.Any(r => r.RoomId == room.RoomId))
            {
                var locked = GetAllRoomLocked
                    .Where(r => r.RoomId == room.RoomId)
                    .Where(r=>r.RoomCheckIn<=CheckIn && r.RoomCheckOut>CheckIn);
                return locked.Select(r => r.RoomQuantity).Sum();
            }
            else
            {
                return 0;
            }
            
        }

        public int IsRoomOccupied(Room room,DateOnly CheckIn, DateOnly CheckOut)
        {
            if (GetAllRoomOccupied.Any(r => r.RoomId == room.RoomId))
            {
                var occupied = GetAllRoomOccupied
                    .Where(r => r.RoomId == room.RoomId)
                    .Where(r => r.RoomCheckIn <= CheckIn && r.RoomCheckOut >= CheckIn && !r.IsCancelled);
                return occupied.Select(r => r.RoomQuantity).Sum();
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<FacilityType> GetAppliedFacilities(int roomtypeid)
        {
            var appliedfacilities = _dbcontext.FacilityApply.Where(f=>f.RoomTypeId==roomtypeid);
            var availablefacilities = GetAllFacilities.Where(f => appliedfacilities.Select(f=>f.FacilityTypeId).Contains(f.FacilityTypeId));
            return availablefacilities;
        }
    }
}
