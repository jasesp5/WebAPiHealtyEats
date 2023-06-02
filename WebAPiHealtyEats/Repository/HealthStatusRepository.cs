using System.Linq;
using WebApiHealtyEats.Data;
using WebAPiHealtyEats.Repository.IRepository;

namespace WebAPiHealtyEats.Repository
{
    public class HealthStatusRepository : IHealthStatusRepository
    {
        private readonly ApplicationDbContext _dataBase;

        public HealthStatusRepository(ApplicationDbContext applicationDbContext)
        {
            _dataBase = applicationDbContext;

        }
        public string GetDescriptionById(int idHealtStatus)
        {
            var healthStatus = _dataBase.HealthStatuses.FirstOrDefault(h => h.Id == idHealtStatus);
            return healthStatus.Description;
        }
    }
}
