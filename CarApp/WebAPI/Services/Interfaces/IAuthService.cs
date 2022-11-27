using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject.User;

namespace WebAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginUserResponseDTO> Login(LoginUserDTO loginUserDto);
        Task LogOut();
        Task<UserResponseDTO> RegisterUser(RegisterUserDTO registerUserDto);

    }
}