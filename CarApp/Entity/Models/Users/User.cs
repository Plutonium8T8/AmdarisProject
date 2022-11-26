using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Models.Offers;

namespace Entity.Models.Users
{
    public class User : IdentityUser<long>
    {
        [MaxLength(32)]
        [Required]
        public override string UserName { get; set; }

        /*        [MaxLength(32)]
                [Required]
                public string LastName { get; set; }*/

        [MaxLength(32)]
        [EmailAddress]
        public override string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }
        public DateTime RegisterTimestamp { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
