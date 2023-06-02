using System.ComponentModel.DataAnnotations;

namespace WebAPiHealtyEats.Models
{
    public class HealthStatus
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
