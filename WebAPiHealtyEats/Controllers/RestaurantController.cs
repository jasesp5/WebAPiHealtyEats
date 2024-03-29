﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPiHealtyEats.Models;
using WebAPiHealtyEats.Models.Dtos;
using WebAPiHealtyEats.Repository;
using WebAPiHealtyEats.Repository.IRepository;

namespace WebAPiHealtyEats.Controllers
{
    [Route("api/Restaurant")]
    [ApiController]
    public class RestaurantController : Controller
    {

        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        protected ResponseApi _responseApi;

        public RestaurantController(IRestaurantRepository restaurantRepo, IMapper mapper)
        {
            _restaurantRepository = restaurantRepo;
            _mapper = mapper;
            this._responseApi = new();

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetRetaurants()
        {
            var listUsers = _restaurantRepository.GetRetaurants();

            var listRestaurants = new List<RestaurantDto>();

            foreach (var lista in listUsers)
            {
                listRestaurants.Add(_mapper.Map<RestaurantDto>(lista));
            }
            return Ok(listRestaurants);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRestaurantById(int id)
        {
            var restaurant = _restaurantRepository.GetRestaurant(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return Ok(restaurantDto);
        }

        [HttpPost("addRestaurant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddRestaurant([FromBody] RestaurantDto restaurantDto)
        {
            var restaurant = await _restaurantRepository.AddRestaurant(restaurantDto);

            if (restaurant == null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSucess = false;
                _responseApi.ErrorMessages.Add("Error in the registration");
                return BadRequest(_responseApi);

            }

            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSucess = true;
            return Ok(_responseApi);
        }

        [HttpGet("ByCity/{city}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  IActionResult GetRestaurantsByCity(string city)
        {
            var restaurants =   _restaurantRepository.GetRetaurantsByCity(city);
            if (restaurants == null || restaurants.Count == 0)
            {
                return NotFound();
            }
            var restaurantDtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return Ok(restaurantDtos);
        }

        [HttpGet("AllCities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllCities()
        {
            var cities = _restaurantRepository.GetAllCities();
            return Ok(cities);
        }



    }
}
