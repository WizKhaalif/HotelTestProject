using System;
using System.Collections.Generic;
using System.Text;
using HotelAdministrationSystem.Domain.Entities;

namespace HotelAdministrationSystem.Contracts.Dto
{
    public class ClientDto
    {
        public Guid ClientGuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public Guid RoomGuid { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public ClientDto(Client client)
        {
            ClientGuid = client.ClientGuid;
            Name = client.Name;
            Surname = client.Surname;
            Patronymic = client.Patronymic;
            RoomGuid = client.RoomGuid;
            EntryDate = client.EntryDate;
            DepartureDate = client.DepartureDate;
        }
    }
}
