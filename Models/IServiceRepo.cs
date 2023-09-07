

using ParkView_Capstone.Models.Servicess;

namespace ParkView_Capstone.Models
{
    public interface IServiceRepo
    {
        public IEnumerable<Services> GetAllServices { get; }
    }
}
