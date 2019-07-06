using HotelAdministrationSystem.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAdministrationSystem.Contracts.Dto
{
    public class RoomDto
    {
        public Guid RoomGuid { get; set; }
        public int Capacity { get; set; }
        public RoomTypeOption RoomType { get; set; }
    }
}
