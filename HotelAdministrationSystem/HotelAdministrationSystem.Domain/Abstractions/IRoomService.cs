using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;
using System;
using System.Linq;
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
