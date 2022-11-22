using AutoMapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject;
using WebAPI.Model.DataTransferObject.User;

namespace WebAPI.Model.Mapping
{
    public class UserRegisterProfile : Profile
    {
        public UserRegisterProfile()
        {
            CreateMap<RegisterUserDTO, User>();

            CreateMap<RegisterUserDTO, UserResponseDTO>();
        }
    }
}