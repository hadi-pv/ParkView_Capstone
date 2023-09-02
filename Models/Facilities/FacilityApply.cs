using ParkView_Capstone.Models.Room;

namespace ParkView_Capstone.Models.Facilities
{
    public class FacilityApply
    {
        public int FacilityApplyId { get; set; }
        public int FacilityTypeId { get; set; }
        public int RoomTypeId { get; set; }

        public FacilityType FacilityType { get; set; }
        public RoomType RoomType { get; set; }
    }
}
