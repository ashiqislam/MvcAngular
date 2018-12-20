using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularApp.Models;

namespace AngularApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly Ship_UserContext _context;

        public UserRepository(Ship_UserContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string id)
        {
            var user = await _context.Users
               .FirstOrDefaultAsync(u => u.Id == id);
            return (User)user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = (from u in _context.Users
                         select u).AsQueryable().ToListAsync();
            return (IEnumerable<User>)users;
        }

        public async Task<bool> SaveAll()
        {
            var numberOfChanges = await _context.SaveChangesAsync();
            return (numberOfChanges > 0);
        }

        void IUserRepository.Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetUser(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IUserRepository.GetUsers()
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}