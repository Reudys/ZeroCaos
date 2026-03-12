using ZeroCaos_BackEnd.Data;
using ZeroCaos_BackEnd.Interfaces;
using ZeroCaos_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace ZeroCaos_BackEnd.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context) { _context = context; }

        #region CRUD Methods
        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            var findUser = await _context.Users.FindAsync(id);
            if (findUser == null) return null;
            findUser.Name = user.Name;
            findUser.Username = user.Username;
            findUser.Password = user.Password;
            await _context.SaveChangesAsync();
            return findUser;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var findUser = await _context.Users.FindAsync(id);
            if (findUser == null) return false;
            _context.Users.Remove(findUser);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Custom Methods
        //Arreglar
        public async Task<bool> LoginAsync(string user, string password)
        {
            var u = await _context.Users.FirstOrDefaultAsync(u => u.Username == user && u.Password == password);
            if (u == null) return false;
            return true;
        }
        #endregion
    }
}
