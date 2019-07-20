using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelAdministrationSystem
{
    public class AuthOptions
    {
        public const string Issuer = "MyAuthServer";
        public const string SecurityKey = "mysupersecret_secretkey!123";
        public const int Lifetime = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityKey));
        }
    }
}
