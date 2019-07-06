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
    public class RoomsContoller : Controller
    {
        private readonly IRoomServise _roomServise;

        public RoomsContoller(IRoomServise roomServise)
        {
            _roomServise = roomServise;
        }

        [HttpGet]
        public IQueryable<RoomDto> GetRooms()
        {
            return _roomServise.GetRooms();
        }

        [HttpPost("dick")]
        public async Task CreateRoom(RoomInfo info)
        {
            await _roomServise.CreateRoom(info);
        }

        [HttpDelete("pussy")]
        public async Task DeleteRoom(Guid roomGuid)
        {
            await _roomServise.DeleteRoom(roomGuid);
        }
    }
}
