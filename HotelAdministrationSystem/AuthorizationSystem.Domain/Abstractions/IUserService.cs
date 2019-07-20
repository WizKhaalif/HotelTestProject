using AuthorizationSystem.Contracts.Actions;
using AuthorizationSystem.Domain.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationSystem.Domain.Abstractions
{
    public interface IUserService
    {
        ClaimsIdentity GetIdentity(string username, string password);
        Task CreateUser(UserInfo info);
        Task DeleteUser(string username);
        Token IssueToken(ClaimsIdentity identity);
        Task<Token> GetToken(UserInfo info);
    }
}
