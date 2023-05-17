using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPiHealtyEats.Models;
using WebAPiHealtyEats.Models.Dtos;
using WebAPiHealtyEats.Repository;
using WebAPiHealtyEats.Repository.IRepository;

namespace WebAPiHealtyEats.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IMapper _mapper;
        protected ResponseApi _responseApi;

        public UsersController(IUsuarioRepository userRepo, IMapper mapper)
        {
            _userRepository = userRepo;
            _mapper = mapper;
            this._responseApi = new();

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            var listUsers = _userRepository.GetUsers();

            var listaUsersDto = new List<UserDto>();

            foreach (var lista in listUsers)
            {
                listaUsersDto.Add(_mapper.Map<UserDto>(lista));
            }
            return Ok(listaUsersDto);
        }



        [HttpGet("{userId:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(int userId)
        {
            var itemUser = _userRepository.GetUser(userId);

            if (itemUser == null)
            {
                return NotFound();
            }

            var itemUserDto = _mapper.Map<UserDto>(itemUser);
            return Ok(itemUserDto);
        }


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UserDtoRegistro userDtoRegistro)
        {
            bool validateUserName = _userRepository.IsUniqueUser(userDtoRegistro.UserName);
            if (validateUserName)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSucess = false;
                _responseApi.ErrorMessages.Add("The user name already exists");
                return BadRequest(_responseApi);

            }

            var user = await _userRepository.Register(userDtoRegistro);

            if (user == null)
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



        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logi([FromBody] UserLogin userLogin)
        {
            try
            {
                var responseLogin = await _userRepository.Login(userLogin);
                if (responseLogin == null)
                {
                    _responseApi.StatusCode = HttpStatusCode.BadRequest;
                    _responseApi.IsSucess = false;
                    _responseApi.ErrorMessages.Add("The username or the password do not exist");
                    return BadRequest(_responseApi);
                }
                _responseApi.StatusCode = HttpStatusCode.OK;
                _responseApi.IsSucess = true;
                _responseApi.Result = responseLogin;
                return Ok(_responseApi);
            }
            catch (Exception ex)
            {
                // Handle the exception
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSucess = false;
                _responseApi.ErrorMessages.Add(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, _responseApi);
            }
        }


    }

}

