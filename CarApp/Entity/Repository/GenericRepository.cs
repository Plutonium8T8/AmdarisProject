﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GenericRepository : IRepository<T> where T : Class
    {
    }
}
