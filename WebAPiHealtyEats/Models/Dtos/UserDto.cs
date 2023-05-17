﻿using System.ComponentModel.DataAnnotations;

namespace WebAPiHealtyEats.Models.Dtos
{
    public class UserDto

    {
        [Key]

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
