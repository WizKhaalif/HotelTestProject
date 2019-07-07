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
        private readonly IClientServise _clientServise;

        public ClientsContoller(IClientServise clientServise)
        {
            _clientServise = clientServise;
        }

        [HttpGet]
        public IQueryable<ClientDto> GetClients()
        {
            return _clientServise.GetClients();
        }

        [HttpPost("addclient")]
        public async Task CreateClient(ClientInfo info)
        {
            await _clientServise.CreateClient(info);
        }

        [HttpDelete("deleteclient")]
        public async Task DeleteClient(Guid clientGuid)
        {
            await _clientServise.DeleteClient(clientGuid);
        }
    }
}
