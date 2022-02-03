using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using hunchedDogBackend.Models;
using hunchedDogBackend.UsersData;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

namespace hunchedDogBackend.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UserData _authData = new UserData();

        [HttpPost]
        [Route("auth/sign_up")]
        public async Task<IActionResult> Registration([FromBody] User user)
        {
            /*return Ok(user);*/
            return Ok(await _authData.Registration(user));
        }

       

        [HttpPost]
        [Route("auth/sign_in")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            
            if (await _authData.Login(user, "") == "Login is successed")
            {
                var Jwt = await GenerateJwtToken(user.Email, user.Password);
                var FoundUser = await Profile(user.Email);
                var response = new { Jwt, FoundUser };
                return Ok(response);;

            }
            return BadRequest("User isn't found, try again");
        }

        [HttpGet]
        [Route("user/profile/{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            return Ok(await _authData.GetProfile(id));
        }


       /* [HttpPost("loginTest")]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            var username = "Prerak";
            if (username == "Prerak")
            {
                var token = await GenerateJwtToken(username);
                return Ok(new { user = username, token = token });
            }
            else
            {
                return BadRequest("Invalid User");
            }
        }*/

        private async Task<string> GenerateJwtToken(string email, string password)
        {
            var someSecret = "a very random string which should";
            List<Claim> claims = new List<Claim>() {
            new Claim(ClaimTypes.Name,email),
            new Claim(ClaimTypes.Hash,password),

            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(someSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken SecurityToken = new JwtSecurityToken(
                issuer: "myapi.com",
                audience: "myapi.com",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
                );

            return await Task.Run<string>(() =>
            {
                return jwtTokenHandler.WriteToken(SecurityToken);
            });
        }

        private async Task<User> Profile(string email)
        {
            using (HunchedContext db = new HunchedContext())
            {

                var profiles = await db.Users.ToListAsync();

                var neededProfile = profiles.Find(x => x.Email == email);
                if (neededProfile != null)
                {
                    return neededProfile;
                }

            }
            return null;
        }

    }
}
