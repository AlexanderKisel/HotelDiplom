using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hotel.Services.Contracts
{
    /// <summary>
    /// Настройки аунтификации
    /// </summary>
    public class Auth
    {
        public const string ISSUER = "https://localhost:7055/";
        public const string AUDIENCE = "https://localhost:7055/";
        const string KEY = "superSecretKey@123456fdsdffsdasdadsasdfdf";
        public const int LIFETIME = 500;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
