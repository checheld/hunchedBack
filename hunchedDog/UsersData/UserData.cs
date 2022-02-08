using hunchedDogBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace hunchedDogBackend.UsersData
{
    public class UserData : IUser
    {
        public async Task<string> Registration(User user)
        {
            string response = "User can't be added";
            using (HunchedContext db = new HunchedContext())
            {
                var profile = await db.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
                if (profile == null)
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

        public async Task<bool> Login(User user)
        {
            using (HunchedContext db = new HunchedContext())
            {
                var currentUser = await db.Users.FirstOrDefaultAsync(x => x.Email == user.Email
                && x.Password == user.Password);

                if (currentUser != null)
                {
                    User withToken = new User()
                    {
                        Id = currentUser.Id,
                        Email = currentUser.Email,
                        Password = currentUser.Password,
                        First_name = currentUser.First_name,
                        Last_name = currentUser.Last_name,
                    };
                    db.Remove(currentUser);
                    await db.AddAsync(withToken);
                    await db.SaveChangesAsync();

                    return true;
                }

                return false;
            }
        }

        public async Task<User> GetProfile(int id)
        {
            using (HunchedContext db = new HunchedContext())
            {

                var profile = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

                //var profiles = await db.Users.ToListAsync();

                //var neededProfile = profiles.FirstOrDefault(x => x.Id == id);
                //if (neededProfile != null)
                //{
                //    return neededProfile;
                //}
                return profile;
            }
        }
    }
}