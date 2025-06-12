using Interview_Practical_Session.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace Interview_Practical_Session.DLL
{
    public class UserService : IUserService
    {
        private readonly DbContextClass _dbContextClass;
        public UserService(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public async Task<User> CreateAsync(User user)
        {
            _dbContextClass.Users.Add(user);
            await _dbContextClass.SaveChangesAsync();

            return user; // Return the created user
        }

        public async Task<bool> DeleteAsync(User user)
        {
            var users = await _dbContextClass.Users.FindAsync(user.Id);
            if (user == null)
            {
                return false; // User not found
            }

            _dbContextClass.Users.Remove(users);
            await _dbContextClass.SaveChangesAsync();
            return true; // User deleted successfully
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContextClass.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int Id)
        {
          return await _dbContextClass.Users
                .FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            _dbContextClass.Users.Update(user);
            await _dbContextClass.SaveChangesAsync();
            return user;
        }
    }
}
