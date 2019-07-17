using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;
using HotelAdministrationSystem.Domain.Abstractions;
using HotelAdministrationSystem.Domain.DataBase;
using HotelAdministrationSystem.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelAdministrationSystem.Domain.Services
{
    public class ClientService : IClientService
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
            var room = await _context.Rooms.FindAsync(info.RoomGuid);
            if (room != null)
                if (room.Capacity > room.Residents && info.DepartureDate > info.EntryDate && info.EntryDate >= DateTime.Today)
                {
                    room.Residents++;
                    room.Occupied = true;
                    var client = new Client(info);
                    _context.Clients.Add(client);
                }
            await _context.SaveChangesAsync();
        }

        public async Task EvictClient(Guid clientGuid)
        {
            var client = await _context.Clients.FindAsync(clientGuid);
            var room = await _context.Rooms.FindAsync(client.RoomGuid);
            room.Residents--;
            if (room.Residents == 0)
            {
                room.Occupied = false;
                client.Bill = (int)(DateTime.Today - client.EntryDate).TotalDays * room.Price;
            }
            client.NowStaying = false;
            client.RoomGuid = Guid.Empty;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClients()
        {
            var clients = _context.Clients.Where(c => c.DepartureDate < DateTime.Now && c.NowStaying == true).ToList();
            foreach (Client client in clients)
            {
                await EvictClient(client.ClientGuid);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(Guid clientGuid)
        {
            var client = await _context.Clients.FindAsync(clientGuid);
            if (client.NowStaying == false)
            {
                _context.Clients.Remove(client);
            }
            await _context.SaveChangesAsync();
        }
    }
}
