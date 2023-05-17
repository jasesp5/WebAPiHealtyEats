using WebApiHealtyEats.Models;
using WebAPiHealtyEats.Models.Dtos;

namespace WebAPiHealtyEats.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        ICollection<User> GetUsers();

        User GetUser(int idUser);

        bool IsUniqueUser(String userName);

        bool IsUniqueEmail(String email);

        Task<UserLoginRespond> Login(UserLogin userLogin);

        Task<User> Register(UserDtoRegistro userDtoRegistro);

    }
}
