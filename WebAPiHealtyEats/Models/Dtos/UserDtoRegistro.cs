using System.ComponentModel.DataAnnotations;

namespace WebAPiHealtyEats.Models.Dtos
{
    public class UserDtoRegistro
    {
        [Required(ErrorMessage ="El usuario es obligatorio")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string Password { get; set; }
    }
}
