using BlazorDemo.Models;

namespace BlazorDemo.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<List<User>> GetAll();
        Task<User?> GetById(int id);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
    }
}
