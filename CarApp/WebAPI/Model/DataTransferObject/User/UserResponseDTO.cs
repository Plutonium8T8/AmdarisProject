using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DataTransferObject.User
{
    public class UserResponseDTO
    {
        public long Id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

/*        public DateTime? DOB { get; set; }*/
    }
}