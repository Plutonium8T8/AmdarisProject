using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DataTransferObject.User
{
    public class UserUpdateDTO
    {
        public long Id { get; set; }

        public string UserName { get; set; }

    }
}