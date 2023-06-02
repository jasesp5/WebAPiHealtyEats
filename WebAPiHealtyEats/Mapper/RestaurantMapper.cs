using AutoMapper;
using WebAPiHealtyEats.Migrations;
using WebAPiHealtyEats.Models;
using WebAPiHealtyEats.Models.Dtos;

namespace WebAPiHealtyEats.Mapper
{
    public class RestaurantMapper : Profile
    {
        public RestaurantMapper() {

            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
        }
    }
}
