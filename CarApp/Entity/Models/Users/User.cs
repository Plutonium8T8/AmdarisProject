﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User : IdentityUser<long>
    {
        [MaxLength(32)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(32)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(32)]
        [EmailAddress]
        public override string Email { get; set; } 

        [Required]
        public DateTime DOB { get; set; }
        public string RegisterTimestamp { get; set; }

        public virtual ICollection<Offer> Oferrs { get; set; }
    }
}
