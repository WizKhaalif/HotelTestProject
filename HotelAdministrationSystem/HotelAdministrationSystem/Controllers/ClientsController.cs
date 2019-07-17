using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using HotelAdministrationSystem.Domain.Abstractions;
using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;
using Microsoft.AspNetCore.Authorization;

namespace HotelAdministrationSystem.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsContoller : Controller
    {
        private readonly IClientService _clientService;

        public ClientsContoller(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IQueryable<ClientDto> GetClients()
        {
            return _clientService.GetClients();
        }

        [HttpPost("AddClient")]
        public async Task CreateClient(ClientInfo info)
        {
            await _clientService.CreateClient(info);
        }

        [HttpPut("EvictClient")]
        public async Task EvictClient(Guid clientGuid)
        {
            await _clientService.EvictClient(clientGuid);
        }

        [HttpPut("UpdateClients")]
        public async Task UpdateClients()
        {
            await _clientService.UpdateClients();
        }

        [HttpDelete("DeleteClient")]
        public async Task DeleteClient(Guid clientGuid)
        {
            await _clientService.DeleteClient(clientGuid);
        }
    }
}
