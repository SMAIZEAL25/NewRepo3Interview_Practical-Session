using Interview_Practical_Session.NewFolder;

namespace Interview_Practical_Session.DLL
{
    public interface IUserService
    {

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int Id);

        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(User user);


    }
}
