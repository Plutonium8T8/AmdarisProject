using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Entity.Models.Users;
using System.Runtime.ConstrainedExecution;

namespace Entity.Models.Cars
{
    public class Car : EntityBaseClass
    {
        public long Id { get; set; }
    }
}