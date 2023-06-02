using WebAPiHealtyEats.Models.Dtos;
using WebAPiHealtyEats.Models;
using AutoMapper;

namespace WebAPiHealtyEats.Mapper
{
    public class HealthStatusMapper : Profile
    {
        public HealthStatusMapper()
        {

            CreateMap<HealthStatus, HealthStatusDto>().ReverseMap();
        }
    }
}
