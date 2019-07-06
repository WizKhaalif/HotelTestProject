using HotelAdministrationSystem.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HotelAdministrationSystem.Contracts.Actions;

namespace HotelAdministrationSystem.Domain.Entities
{
    public class Room
    {
        [Key]
        public Guid RoomGuid { get; set; }
        public int Capacity { get; set; }
        public RoomTypeOption RoomType { get; set; }

        public Room()
        {
            RoomGuid = Guid.NewGuid();
        }

        public Room(RoomInfo info)
        {
            Capacity = info.Capacity;
            RoomType = info.RoomType;
            RoomGuid = Guid.NewGuid();
        }
    }
}
