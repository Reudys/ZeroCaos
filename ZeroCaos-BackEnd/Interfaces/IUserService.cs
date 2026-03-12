using ZeroCaos_BackEnd.Models;

namespace ZeroCaos_BackEnd.Interfaces
{
    public interface IUserService
    {
        #region Crud Methods
        Task<User> CreateAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
        #endregion

        #region Custom Methods
        Task<bool> LoginAsync(string user, string password);
        #endregion
    }
}
