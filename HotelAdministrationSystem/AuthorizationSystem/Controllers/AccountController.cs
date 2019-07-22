using System.Threading.Tasks;
using AuthorizationSystem.Contracts.Actions;
using AuthorizationSystem.Domain.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuthorizationSystem.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/token")]
        public async Task GetToken(UserInfo info)
        {
            if (_userService.GetIdentity(info.Username, info.Password) == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }
            else
            {
                var response = new
                {
                    access_token = _userService.GetToken(info).Result.Value,
                    expiration_date = _userService.GetToken(info).Result.ExpirationDate
                };
                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            }
        }

        [HttpPost("/create")]
        public async Task CreateUser(UserInfo info)
        {
            await _userService.CreateUser(info);
        }

        [HttpDelete("/delete")]
        [Authorize]
        public async Task DeleteUser(string username)
        {
            await _userService.DeleteUser(username);
        }
    }
}