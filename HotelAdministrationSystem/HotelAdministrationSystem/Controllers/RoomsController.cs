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
    public class RoomsContoller : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsContoller(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IQueryable<RoomDto> GetRooms()
        {
            return _roomService.GetRooms();
        }

        [HttpPost("AddRoom")]
        public async Task CreateRoom(RoomInfo info)
        {
            await _roomService.CreateRoom(info);
        }

        [HttpDelete("DeleteRoom")]
        public async Task DeleteRoom(Guid roomGuid)
        {
            await _roomService.DeleteRoom(roomGuid);
        }
    }
}
