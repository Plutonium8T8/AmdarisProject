﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DataTransferObject.User
{
    public class LoginUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}