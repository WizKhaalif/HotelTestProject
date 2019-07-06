using HotelAdministrationSystem.Contracts.Actions;
using HotelAdministrationSystem.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAdministrationSystem.Domain.Abstractions
{
    public interface IClientServise
    {
        IQueryable<ClientDto> GetClients();
        Task CreateClient(ClientInfo info);
        Task DeleteClient(Guid clientGuid);
    }
}
