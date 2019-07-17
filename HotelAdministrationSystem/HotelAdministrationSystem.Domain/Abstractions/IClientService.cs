using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAdministrationSystem.Domain.Abstractions
{
    public interface IClientService
    {
        IQueryable<ClientDto> GetClients();
        Task CreateClient(ClientInfo info);
        Task DeleteClient(Guid clientGuid);
        Task EvictClient(Guid clientGuid);
        Task UpdateClients();
    }
}
