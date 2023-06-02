using WebAPiHealtyEats.Models;

namespace WebAPiHealtyEats.Repository.IRepository
{
    public interface IHealthStatusRepository
    {
        string GetDescriptionById(int idHealtStatus);
    }
}
