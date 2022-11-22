using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Roles
{
    public class Role : IdentityRole<long>
    {
        [MaxLength(32)]
        // Moderator, User, Customer, Guest
        public string? RoleName { get; set; }
    }
}
