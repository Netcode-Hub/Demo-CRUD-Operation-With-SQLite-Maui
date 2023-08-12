
using DemoCRUDOperationWithSQLite.Models;

namespace DemoCRUDOperationWithSQLite.Services
{
    public interface IUserService
    {
        Task<int> AddAsync(User user);
        Task<int> UpdateAsync(User user);
        Task<int> DeleteAsync(User user);

        Task<List<User>> GetAsync();
        Task<User> GetUser(string email);
    }
}
