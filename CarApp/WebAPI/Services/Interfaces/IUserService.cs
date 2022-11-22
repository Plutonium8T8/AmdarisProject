using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject.User;
using WebAPI.Model.DataTransferObject.Offer;

namespace WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> GetUser(long id);
        Task<UserResponseDTO> UpdateUser(UserUpdateDTO userUpdateDto);

        Task DeleteUser(long id);

        Task<ICollection<OfferResoponseDTO>> GetUserOffers(long id);
    }
}