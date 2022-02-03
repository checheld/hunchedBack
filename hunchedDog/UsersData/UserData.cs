
using hunchedDogBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace hunchedDogBackend.UsersData
{
    public class UserData : IUser
    {
        public async Task<string> Registration(User user)
        {
            string response = "User can't be added";
            using (HunchedContext db = new HunchedContext())
            {
                var users = await db.Users.ToListAsync();
                if (users.Find(x => x.Email == user.Email) == null)
                {

                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                    response = "Registration is successed";
                }
                else
                {
                    response = "User is found - just sign in";
                }
            }
            return response;
        }

        public async Task<string> Login(User user, string? token)
        {
            string response = "User can't be added";
            using (HunchedContext db = new HunchedContext())
            {
                var users = await db.Users.ToListAsync();
                var currentUser = users.Find(x => x.Email == user.Email
                && x.Password == user.Password);
                if (currentUser != null)
                {
                    if (token != "")
                    {
                        User withToken = new User()
                        {
                            Id = currentUser.Id,
                            Email = currentUser.Email,
                            Password = currentUser.Password,
                            First_name = currentUser.First_name,
                            Last_name = currentUser.Last_name,
                            /*token = token*/
                        };
                        db.Remove(currentUser);
                        await db.AddAsync(withToken);
                        await db.SaveChangesAsync();
                    }
                    response = "Login is successed";
                }
                else
                {
                    response = "User is not found - just sign up";
                }
            }
            return response;
        }

        public async Task<User> GetProfile(int id)
        {
            using (HunchedContext db = new HunchedContext())
            {
             

                var profiles = await db.Users.ToListAsync();

                var neededProfile = profiles.Find(x => x.Id == id);
                if (neededProfile != null)
                {
                    return neededProfile;
                }

            }
            return null;
        }
    }
}