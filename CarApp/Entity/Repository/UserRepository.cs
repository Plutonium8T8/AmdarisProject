using System;
using System.Collections.Generic;
using System.Linq;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        Exception UserNotFound = new Exception("Entity not found. User does not exist.");
        public UserRepository(AppContext context) : base(context)
        {

        }

        public async Task DeleteUser(long id)
        {
            var res = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
            if (res == null) throw UserNotFound;
            await Delete(res);
        }

        public async Task<User> GetUserByName(string username)
        {
            var res = await _context.Set<User>().FirstOrDefaultAsync(u => u.UserName == username);
            if (res == null) throw UserNotFound;
            return res;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var res = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
            if (res == null) throw UserNotFound;
            return res;
        }

        public async Task<User> SingleUserAndEmail(string username, string email)
        {
            var res = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email || (u.UserName == username));
            if (res == null) throw UserNotFound;
            return res;
        }

        public async Task<User> CreateUser(User user)
        {
            await base.Create(user);

            return user;
        }

        public async Task<ICollection<Offer>> GetOffers(long id)
        {
            var res = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return res?.Offers;
        }
    }
}
