using System;

namespace HotelAdministrationSystem.Contracts.Actions
{
    public class ClientInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public Guid RoomGuid { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
