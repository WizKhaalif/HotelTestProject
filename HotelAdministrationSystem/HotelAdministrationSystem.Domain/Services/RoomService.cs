using System;
using System.Linq;
using System.Threading.Tasks;
using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;
using HotelAdministrationSystem.Domain.Abstractions;
using HotelAdministrationSystem.Domain.DataBase;
using HotelAdministrationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelAdministrationSystem.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelSystemDBContext _context;

        public RoomService(HotelSystemDBContext context)
        {
            _context = context;
        }

        public IQueryable<RoomDto> GetRooms()
        {
            var rooms = _context.Rooms.AsNoTracking().Select(x => new RoomDto(x));
            return rooms;
        }

        public async Task CreateRoom(RoomInfo info)
        {
            var room = new Room(info);
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(Guid roomGuid)
        {
            var room = await _context.Rooms.FindAsync(roomGuid);
            if (room.Occupied == false)
                _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
