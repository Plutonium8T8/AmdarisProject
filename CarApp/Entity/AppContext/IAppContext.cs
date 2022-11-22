﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.Payment;

namespace Entity
{
    public interface IAppContext
    {
        DbSet<Payment> Payments { get; set; }
    }
}
