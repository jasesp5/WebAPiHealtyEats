using System.ComponentModel.DataAnnotations;

namespace WebAPiHealtyEats.Models.Dtos
{
    public class HealthStatusDto
    {

        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
