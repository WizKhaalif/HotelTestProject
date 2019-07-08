﻿// <auto-generated />
using System;
using HotelAdministrationSystem.Domain.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelAdministrationSystem.Migrations
{
    [DbContext(typeof(HotelSystemDBContext))]
    partial class HotelSystemDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HotelAdministrationSystem.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("ClientGuid");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("Name");

                    b.Property<string>("Patronymic");

                    b.Property<Guid>("RoomGuid");

                    b.Property<string>("Surname");

                    b.HasKey("ClientGuid");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HotelAdministrationSystem.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("RoomGuid");

                    b.Property<int>("Capacity");

                    b.Property<bool>("Occupied");

                    b.Property<int>("Residents");

                    b.Property<int>("RoomType");

                    b.HasKey("RoomGuid");

                    b.ToTable("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
