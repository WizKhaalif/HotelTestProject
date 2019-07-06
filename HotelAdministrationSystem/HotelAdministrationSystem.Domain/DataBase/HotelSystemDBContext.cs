using System;
using System.Collections.Generic;
using System.Text;
using HotelAdministrationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelAdministrationSystem.Domain.DataBase
{
    public class HotelSystemDBContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RoomState> RoomStates { get; set; }

        public HotelSystemDBContext(DbContextOptions<HotelSystemDBContext> options) : base(options)
        {

        }
    }
}
