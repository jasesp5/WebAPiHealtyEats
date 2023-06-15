using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiHealtyEats.Models;

namespace WebAPiHealtyEats.Models
{
    public class Restaurant
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public string City { get; set; }

        public String Region { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("HealthStatus")]
        public int HealthStatusId { get; set; }

        public User User { get; set; }

        public HealthStatus HealthStatus { get; set; } 
    }
}
