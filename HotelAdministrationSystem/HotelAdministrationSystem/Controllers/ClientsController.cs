using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAdministrationSystem.Domain.Abstractions;
using HotelAdministrationSystem.Domain.Entities;
using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;

namespace HotelAdministrationSystem.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
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

        [HttpDelete("DeleteClient")]
        public async Task DeleteClient(Guid clientGuid)
        {
            await _clientService.DeleteClient(clientGuid);
        }
    }
}
