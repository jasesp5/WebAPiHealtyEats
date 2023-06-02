using System.ComponentModel.DataAnnotations;

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

        public int UserId { get; set; }

        public int HealthStatusId { get; set; } 
    }
}
