using WebApiHealtyEats.Data;
using WebAPiHealtyEats.Models;
using WebAPiHealtyEats.Models.Dtos;
using WebAPiHealtyEats.Repository.IRepository;

namespace WebAPiHealtyEats.Repository
{
    public class RestaurantRepository : IRestaurantRepository

    {
        private readonly ApplicationDbContext _dataBase;

        public RestaurantRepository(ApplicationDbContext applicationDbContext)
        {
            _dataBase = applicationDbContext;
        
        }
        public async  Task<Restaurant> AddRestaurant(RestaurantDto restaurantDto)
        {
       
            Restaurant restaurant = new Restaurant()
            {
                Name = restaurantDto.Name,
                Street = restaurantDto.Street,
                StreetNumber = restaurantDto.StreetNumber,
                City = restaurantDto.City,
                Region = restaurantDto.Region,
                UserId = restaurantDto.UserId,
                HealthStatusId = restaurantDto.HealthStatusId,
            };
            _dataBase.Restaurant.Add(restaurant);
            await _dataBase.SaveChangesAsync();
            return restaurant;
        }

        public ICollection<string> GetAllCities()
        {
            return _dataBase.Restaurant.OrderBy(restaurant => restaurant.City)
                                      .Select(restaurant => restaurant.City)
                                       .Distinct()
                                      .ToList();

        }

        public Restaurant GetRestaurant(int idRestaurant)
        {
            return _dataBase.Restaurant.FirstOrDefault(restaurant => restaurant.Id == idRestaurant);
        }

        public ICollection<Restaurant> GetRetaurants()
        {
            return _dataBase.Restaurant.OrderBy(restaurant => restaurant.Name).ToList();
        }

        public ICollection<Restaurant> GetRetaurantsByCity(string city)
        {
            return _dataBase.Restaurant.Where(restaurant => restaurant.City == city)
                             .ToList();
        }
    }
}
