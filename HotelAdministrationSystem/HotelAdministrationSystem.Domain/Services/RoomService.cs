﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;
using HotelAdministrationSystem.Contracts.Enums;
using HotelAdministrationSystem.Domain.Abstractions;
using HotelAdministrationSystem.Domain.DataBase;
using HotelAdministrationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelAdministrationSystem.Domain.Services
{
    public class RoomService : IRoomServise
    {
        private readonly HotelSystemDBContext _context;

        public RoomService(HotelSystemDBContext context)
        {
            _context = context;
        }

        public IQueryable<RoomDto> GetRooms()
        {
            var rooms = from r in _context.Rooms
                select new RoomDto()
                {
                    RoomGuid = r.RoomGuid,
                    Capacity = r.Capacity,
                    RoomType = r.RoomType
                };
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
            var room = _context.Rooms.FindAsync(roomGuid);
            _context.Rooms.Remove(room.Result);
            await _context.SaveChangesAsync();
        }
    }
}
