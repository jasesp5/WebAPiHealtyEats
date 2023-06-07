using WebAPiHealtyEats.Models;
using WebAPiHealtyEats.Models.Dtos;

namespace WebAPiHealtyEats.Repository.IRepository
{
    public interface IRestaurantRepository
    {
        ICollection<Restaurant> GetRetaurants();

        Restaurant GetRestaurant(int idRestaurant);
        ICollection<Restaurant> GetRetaurantsByCity(string city);
        ICollection<string> GetAllCities();
        Task<Restaurant> AddRestaurant(RestaurantDto restaurantDto);

    }
}
