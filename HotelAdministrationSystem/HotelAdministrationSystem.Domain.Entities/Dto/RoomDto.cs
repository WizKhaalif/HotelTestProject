using HotelAdministrationSystem.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using HotelAdministrationSystem.Domain.Entities;

namespace HotelAdministrationSystem.Contracts.Dto
{
    public class RoomDto
    {
        public Guid RoomGuid { get; set; }
        public int Capacity { get; set; }
        public int Residents { get; set; }
        public RoomTypeOption RoomType { get; set; }
        public bool Occupied { get; set; }
        public decimal Price { get; set; }

        public RoomDto(Room room)
        {
            RoomGuid = room.RoomGuid;
            Capacity = room.Capacity;
            Residents = room.Residents;
            RoomType = room.RoomType;
            Occupied = room.Occupied;
            Price = room.Price;
        }
    }
}
