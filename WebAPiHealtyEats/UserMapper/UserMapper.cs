using AutoMapper;
using WebApiHealtyEats.Models;
using WebAPiHealtyEats.Models.Dtos;

namespace WebAPiHealtyEats.UserMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {

            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
