using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Entity.Models.Users;
using Entity.Models.Cars;

namespace Entity.Models.Offers
{
    public class Offer : EntityBaseClass
    {
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string Engine { get; set; }
        public string Description { get; set; }
        public string Extra { get; set; }
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
