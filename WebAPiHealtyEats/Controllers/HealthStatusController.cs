using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPiHealtyEats.Repository.IRepository;

namespace WebAPiHealtyEats.Controllers
{
    [Route("api/HeatlhStatus")]
    [ApiController]
    public class HealthStatusController : Controller
    {
        private readonly IHealthStatusRepository _healthStatusRepository;
        private readonly IMapper _mapper;
        public HealthStatusController(IMapper mapper, IHealthStatusRepository healthStatusRepository) { 

            _healthStatusRepository = healthStatusRepository;
            _mapper = mapper;
        
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDescriptionById(int id)
        {
            var description = _healthStatusRepository.GetDescriptionById(id);

            if (description == null)
            {
                return NotFound();
            }

            return Ok(description);
        }
    }

}

