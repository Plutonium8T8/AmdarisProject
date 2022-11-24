using AutoMapper;
using Others.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject;
using WebAPI.Model.DataTransferObject.User;
using WebAPI.Services.Interfaces;
using Entity.Repository.Interfaces;
using Entity.Models.Users;
using WebAPI.Model.Helpers;

namespace WebAPI.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository { get; }
        private IMapper _mapper { get; }
        private SignInManager<User> _signInManager { get; }
        private UserManager<User> _userManager { get; }
        private IOptions<AuthOptions> _authOptions { get; }
        public AuthService(IUserRepository userRepository, IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager, IOptions<AuthOptions> authOptions)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _authOptions = authOptions;
        }

        private async Task<string> GenerateToken(User user)
        {
            var authParams = _authOptions.Value;

            var roles = await _userManager.GetRolesAsync(user);

            var securityKey = authParams.GetSymmetricSecurityKey();

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                };

            roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(authParams.Issuer,
                                            authParams.Audience,
                                            claims, expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<IdentityResult> RegisterNewUser(User user, string password)
        {
            Console.WriteLine(user.UserName);

            user.UserName = "testusername";

            var result = await _userManager.CreateAsync(user, password);

            Console.WriteLine(result.Succeeded);

            if (result.Succeeded)
            {
                await _userRepository.Save();
            }

            return result;
        }

        public async Task<LoginUserResponseDTO> Login(LoginUserDTO loginUserDTO)
        {
            var checkUsername = _userRepository.GetUserByName(loginUserDTO.UserName);

            var checkPassword = await _signInManager.PasswordSignInAsync(loginUserDTO.UserName, loginUserDTO.Password, false, false);

            if (!checkPassword.Succeeded || checkUsername == null)
            {
                throw new InvalidFormException($"", "wrong username or password", StatusCodes.Status401Unauthorized);
            }

            var user = await _userRepository.GetUserByName(loginUserDTO.UserName);

            var token = await GenerateToken(user);

            return new LoginUserResponseDTO { Token = token };
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserResponseDTO> RegisterUser(RegisterUserDTO registerUser)
        {
            var check = await _userRepository.SingleUserAndEmail(username: registerUser.UserName, email: registerUser.Email);

            if (check != null)
            {
                var email = registerUser.Email == check.Email ? "Email - " : "";
                var username = registerUser.UserName == check.UserName ? "Username :" : "";

                throw new EntityAlreadyExistException("", $" {email} {username} already taken!");
            }

            var user = _mapper.Map<User>(registerUser);

            var result = await RegisterNewUser(user, registerUser.Password);

            if (!result.Succeeded)
            {
                throw new InvalidFormException("", result.Errors.Select(e => e.Description).Aggregate((x, res) => res += x + "\n"));
            }

            return _mapper.Map<UserResponseDTO>(registerUser);
        }
    }
}
