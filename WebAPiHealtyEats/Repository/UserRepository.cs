using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiHealtyEats.Data;
using WebApiHealtyEats.Models;
using WebAPiHealtyEats.Models.Dtos;
using WebAPiHealtyEats.Repository.IRepository;
using XSystem.Security.Cryptography;

namespace WebAPiHealtyEats.Repository
{
    public class UserRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _dataBase;

        private string secretKey;
        public UserRepository(ApplicationDbContext applicationDbContext,IConfiguration configuration)
        {
            _dataBase = applicationDbContext;
            secretKey = configuration.GetValue<string>("ApiSettings : Secreta");
        }

        public User GetUser(int idUser)
        {
            return _dataBase.User.FirstOrDefault(user => user.Id == idUser);
        }

        public ICollection<User> GetUsers()
        {
            return _dataBase.User.OrderBy(user => user.Name).ToList();
        }

        public bool IsUniqueEmail(string email)
        {
            var userDataBase = _dataBase.User.FirstOrDefault(user => user.Email == email);
            if (userDataBase != null)
            {
                return true;
            }

            return false;
        }

        public bool IsUniqueUser(string userName)
        {
            var userDataBase = _dataBase.User.FirstOrDefault(user =>user.UserName == userName);
            if (userDataBase != null)
            {
                return true;
            }

            return false;
        }

        public async Task<UserLoginRespond> Login(UserLogin userLogin)
        {
            var passwordCripted = getmd5(userLogin.Password);

            var user = _dataBase.User.FirstOrDefault(u =>
                u.Password == passwordCripted && u.UserName.ToLower() == userLogin.UserName.ToLower()
            );

            if (user != null)
            {
                // Procesamos el login 
                var manejadorToken = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("Hola que tal esta es una frase para ver si funciona o no");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = manejadorToken.CreateToken(tokenDescriptor);

                UserLoginRespond userLoginRespond = new UserLoginRespond()
                {
                    Token = manejadorToken.WriteToken(token),
                    User = user
                };

                return userLoginRespond;
            }

            // User not found or password does not match
            return null;
        }


        public async Task<User> Register(UserDtoRegistro userDtoRegistro)
        {
            var passwordCripted = getmd5(userDtoRegistro.Password);
            User user = new User()
            {
                Name = userDtoRegistro.Name,
                UserName = userDtoRegistro.UserName,
                Password = passwordCripted,
                Email = userDtoRegistro.Email,
            };
            _dataBase.User.Add(user);
            await _dataBase.SaveChangesAsync();
            user.Password = passwordCripted;
            return user;
        }
        //Método para encriptar contraseñna con MD5
        public static string getmd5(String value)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(value);
            data = mD5CryptoServiceProvider.ComputeHash(data);
            string response = "";
            for (int i= 0; i < data.Length;i++)
                response += data[i].ToString("x2").ToLower();

            return response;
        }
    }
}
