using AutoMapper;
using Entity.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject.User;

namespace WebAPI.Model.Mapping
{
    public class UserToResponse : Profile
    {
        public UserToResponse()
        {
            CreateMap<User, UserResponseDTO>().ForMember(u => u.Phone, mapper => mapper.MapFrom(u => u.PhoneNumber));
        }
    }
}