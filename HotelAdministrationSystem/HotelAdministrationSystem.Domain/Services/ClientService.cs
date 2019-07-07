using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;
using HotelAdministrationSystem.Domain.Abstractions;
using HotelAdministrationSystem.Domain.DataBase;
using HotelAdministrationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelAdministrationSystem.Domain.Services
{
    public class ClientService : IClientServise
    {
        private readonly HotelSystemDBContext _context;

        public ClientService(HotelSystemDBContext context)
        {
            _context = context;
        }

        public IQueryable<ClientDto> GetClients()
        {
            var clients = _context.Clients.AsNoTracking().Select(x => new ClientDto(x));
            return clients;
        }   

        public async Task CreateClient(ClientInfo info)
        {
            var client = new Client(info);
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(Guid clientGuid)
        {
            var client = _context.Clients.FindAsync(clientGuid);
            _context.Clients.Remove(client.Result);
            await _context.SaveChangesAsync();
        }
    }
}
