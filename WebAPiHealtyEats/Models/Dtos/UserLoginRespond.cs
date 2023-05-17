using WebApiHealtyEats.Models;

namespace WebAPiHealtyEats.Models.Dtos
{
    public class UserLoginRespond
    {
        public User User { get; set; }    

        public string Token { get; set;} 
    }
}
