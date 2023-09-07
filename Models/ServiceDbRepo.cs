using ParkView_Capstone.Models.Servicess;

namespace ParkView_Capstone.Models
{
    public class ServiceDbRepo : IServiceRepo
    {
        ParkViewDbContext _dbcontext;

        public ServiceDbRepo(ParkViewDbContext parkViewDbContext)
        {
            _dbcontext = parkViewDbContext;
        }
        public IEnumerable<Services> GetAllServices => _dbcontext.Services;
    }
}
