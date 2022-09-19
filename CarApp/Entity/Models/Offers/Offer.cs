using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Offer : EntityBaseClass
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Car ImpliedCar { get; set; }

        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
