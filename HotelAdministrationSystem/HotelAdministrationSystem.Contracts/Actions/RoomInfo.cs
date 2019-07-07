﻿using HotelAdministrationSystem.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAdministrationSystem.Contracts.Actions
{
    public class RoomInfo
    {
        public int Capacity { get; set; }
        public int Residents { get; set; }
        public RoomTypeOption RoomType { get; set; }
    }
}
