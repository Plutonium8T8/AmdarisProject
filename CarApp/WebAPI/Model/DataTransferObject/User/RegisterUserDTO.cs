using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DataTransferObject.User
{
    public class RegisterUserDTO
    {
        [Required]
        [MaxLength(32)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(32)]
        public string Phone { get; set; }
        [MaxLength(320)]
        [EmailAddress]
        public string Email { get; set; }
    }
}