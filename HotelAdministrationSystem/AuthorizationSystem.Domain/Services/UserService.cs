using AuthorizationSystem.Contracts.Actions;
using AuthorizationSystem.Controllers;
using AuthorizationSystem.Domain.Abstractions;
using AuthorizationSystem.Domain.Database;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationSystem.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly UserDBContext _context;

        public UserService(UserDBContext context)
        {
            _context = context;
        }

        public ClaimsIdentity GetIdentity(string username, string password)
        {
            User user = _context.Users.Where(x => x.Username == username && x.Password == password).First();
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

        public async Task CreateUser(UserInfo info)
        {
            if (_context.Users.Where(x => x.Username == info.Username).Count() == 0)
            {
                var user = new User(info);
                _context.Users.Add(user);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(string username)
        {
            var user = await _context.Users.FindAsync(username);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
