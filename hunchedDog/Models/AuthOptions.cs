using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace hunchedDogBackend.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "valuableKeySequence";   // ключ для шифрации
        public const int LIFETIME = 7280; // время жизни токена - 7280 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
