using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAdministrationSystem.Contracts.Dto
{
    public class ClientDto
    {
        public Guid ClientGuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
