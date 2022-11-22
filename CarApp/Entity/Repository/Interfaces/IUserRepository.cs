using Entity.Models.Offers;
using Entity.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByName(string username);
        Task<User> GetUserByEmail(string email);
        Task<User> CreateUser(User user);
        Task<User> SingleUserAndEmail(string username, string email);
        Task DeleteUser(long id);
        Task<ICollection<Offer>> GetOffers(long id);
    }
}
