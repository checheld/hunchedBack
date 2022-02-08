using hunchedDogBackend.Models;

namespace hunchedDogBackend.UsersData
{
    public interface IUser
    {
        Task<bool> Login(User user);
        Task<string> Registration(User user);
        Task<User> GetProfile(int id);
    }
}
