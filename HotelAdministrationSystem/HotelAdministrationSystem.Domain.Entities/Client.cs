using HotelAdministrationSystem.Contracts.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelAdministrationSystem.Domain.Entities
{
    public class Client
    {
        [Key]
        public Guid ClientGuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public Client()
        {
            ClientGuid = Guid.NewGuid();
        }

        public Client(ClientInfo info)
        {
            Name = info.Name;
            Surname = info.Surname;
            Patronymic = info.Patronymic;
            EntryDate = info.EntryDate;
            DepartureDate = info.DepartureDate;
            ClientGuid = Guid.NewGuid();
        }
    }
}
