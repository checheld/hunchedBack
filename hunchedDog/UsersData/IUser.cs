using hunchedDogBackend.Models;

namespace hunchedDogBackend.UsersData
{
    public interface IUser
    {
        Task<string> Login(User user, string? token);
        Task<string> Registration(User user);
        Task<User> GetProfile(int id);
    }
}
