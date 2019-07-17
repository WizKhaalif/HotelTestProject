using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using AuthorizationSystem.Contracts;
using AuthorizationSystem.Contracts.Actions;
using AuthorizationSystem.Domain.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public async Task Token(UserInfo info)
        {
            var identity = _userService.GetIdentity(info.Username, info.Password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }
            var now = DateTime.Now;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
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