using BlazorDemo.Data;
using BlazorDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlazorDemoContext _context;
        public UserRepository(BlazorDemoContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                bool exists = _context.User.Any(x => x.Id == user.Id);
                if (!exists) return false;

                _context.Attach(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException) 
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x =>x.Id == id);
            if (user is null) return false;

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
