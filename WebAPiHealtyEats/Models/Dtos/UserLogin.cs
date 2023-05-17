using System.ComponentModel.DataAnnotations;

namespace WebAPiHealtyEats.Models.Dtos
{
    public class UserLogin
    {
        [Required(ErrorMessage = "El username es obligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La password es obligatorio")]
   
        public string Password { get; set; }
    }
}
