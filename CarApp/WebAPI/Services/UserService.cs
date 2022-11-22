using AutoMapper;
using Others.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject.Offer;
using WebAPI.Model.DataTransferObject.User;
using WebAPI.Services.Interfaces;
using Entity.Repository.Interfaces;
using Entity.Models.Users;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; }
        private IOfferRepository _offerRepository { get; }
        private UserManager<User> _userManager { get; }
        private IMapper _mapper { get; }

        public UserService(IUserRepository userRepository, IOfferRepository offerRepository, UserManager<User> userManager, IMapper mapper)
        {
            _userRepository = userRepository;
            _offerRepository = offerRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        private void checkExistance(User user)
        {
            if (user == null)
                throw new EntityNotFoundException("", "No such user exist");
        }

        public async Task DeleteUser(long id)
        {
            var result = await _userRepository.GetEntity(id);

            checkExistance(result);

            await _userRepository.DeleteUser(id);
        }

        public async Task<UserResponseDTO> GetUser(long id)
        {
            var user = await _userRepository.GetEntity(id);

            checkExistance(user);

            var output = _mapper.Map<UserResponseDTO>(user);

            return output;
        }

        public async Task<ICollection<OfferResoponseDTO>> GetUserOffers(long id)
        {
            var result = await _userRepository.GetOffers(id);

            var output = _mapper.Map<ICollection<OfferResoponseDTO>>(result);

            return output;
        }

        public async Task UpdateUser(UserUpdateDTO userUpdate)
        {
            var result = await _userManager.FindByIdAsync(userUpdate.Id.ToString());

            checkExistance(result);

            result.UserName = userUpdate.UserName;

            await _userRepository.Update(result);
        }
    }
}
