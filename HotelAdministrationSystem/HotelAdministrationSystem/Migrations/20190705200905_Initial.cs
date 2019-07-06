using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAdministrationSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientGuid);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomGuid = table.Column<Guid>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    RoomType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomGuid);
                });

            migrationBuilder.CreateTable(
                name: "RoomStates",
                columns: table => new
                {
                    RoomStateGuid = table.Column<Guid>(nullable: false),
                    RoomGuid = table.Column<Guid>(nullable: false),
                    ClientGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStates", x => x.RoomStateGuid);
                    table.ForeignKey(
                        name: "FK_RoomStates_Clients_ClientGuid",
                        column: x => x.ClientGuid,
                        principalTable: "Clients",
                        principalColumn: "ClientGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomStates_Rooms_RoomGuid",
                        column: x => x.RoomGuid,
                        principalTable: "Rooms",
                        principalColumn: "RoomGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomStates_ClientGuid",
                table: "RoomStates",
                column: "ClientGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RoomStates_RoomGuid",
                table: "RoomStates",
                column: "RoomGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomStates");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
