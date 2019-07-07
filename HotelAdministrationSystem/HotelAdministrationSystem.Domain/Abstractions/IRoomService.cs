using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;
using HotelAdministrationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAdministrationSystem.Domain.Abstractions
{
    public interface IRoomService
    {
        IQueryable<RoomDto> GetRooms();
        Task CreateRoom(RoomInfo info);
        Task DeleteRoom(Guid roomGuid);
    }
}
