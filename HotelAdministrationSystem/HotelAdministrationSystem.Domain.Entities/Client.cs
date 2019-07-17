using HotelAdministrationSystem.Contracts.Actions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAdministrationSystem.Domain.Entities
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ClientGuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        [ForeignKey(nameof(Room))]
        public Guid RoomGuid { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Bill { get; set; }
        public bool NowStaying { get; set; }

        public Client()
        {
            ClientGuid = Guid.NewGuid();
        }

        public Client(ClientInfo info)
        {
            ClientGuid = Guid.NewGuid();
            Name = info.Name;
            Surname = info.Surname;
            Patronymic = info.Patronymic;
            RoomGuid = info.RoomGuid;
            EntryDate = info.EntryDate;
            DepartureDate = info.DepartureDate;
            Bill = 0;
            NowStaying = true;
        }
    }
}
