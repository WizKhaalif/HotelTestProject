using HotelAdministrationSystem.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HotelAdministrationSystem.Contracts.Actions;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAdministrationSystem.Domain.Entities
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid RoomGuid { get; set; }
        public int Capacity { get; set; }
        public int Residents { get; set; }
        public RoomTypeOption RoomType { get; set; }
        public bool Occupied { get; set; }
        public decimal Price { get; set; }

        public Room()
        {
            RoomGuid = Guid.NewGuid();
        }

        public Room(RoomInfo info)
        {
            RoomGuid = Guid.NewGuid();
            Capacity = info.Capacity;
            Residents = 0;
            RoomType = info.RoomType;
            Occupied = false;
            Price = info.Price;
        }
    }
}
