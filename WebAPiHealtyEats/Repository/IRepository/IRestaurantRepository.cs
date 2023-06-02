using WebAPiHealtyEats.Models;
using WebAPiHealtyEats.Models.Dtos;

namespace WebAPiHealtyEats.Repository.IRepository
{
    public interface IRestaurantRepository
    {
        ICollection<Restaurant> GetRetaurants();

        Restaurant GetRestaurant(int idRestaurant);


        Task<Restaurant> AddRestaurant(RestaurantDto restaurantDto);

    }
}
