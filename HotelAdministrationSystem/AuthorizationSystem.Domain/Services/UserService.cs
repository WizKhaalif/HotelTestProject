using AuthorizationSystem.Contracts.Actions;
using AuthorizationSystem.Controllers;
using AuthorizationSystem.Domain.Abstractions;
using AuthorizationSystem.Domain.Database;
using AuthorizationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthorizationSystem.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Security.Principal;

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
            if (_context.Users.Where(x => x.Username == username && x.Password == password).Count() != 0)
            {
                User user = _context.Users.Where(x => x.Username == username && x.Password == password).First();
                var identity = new ClaimsIdentity(new GenericIdentity(user.Username), new[]
                {
                    new Claim("username", user.Username),
                    new Claim("role", user.Role)
                });
                return identity;
            }
            else
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

        public Token IssueToken(ClaimsIdentity identity)
        {
            var securityKey = AuthOptions.GetSymmetricSecurityKey();
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.CreateJwtSecurityToken(AuthOptions.Issuer,
                subject: identity,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)));
            return new Token
            {
                Value = jwtTokenHandler.WriteToken(token),
                ExpirationDate = token.ValidTo
            };
        }

        public Task<Token> GetToken(UserInfo info)
        {
            var identity = GetIdentity(info.Username, info.Password);
            var token = IssueToken(identity);
            return Task.FromResult(token);
        }
    }
}
