using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAdministrationSystem.Migrations
{
    public partial class billsupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NowStaying",
                table: "Clients",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NowStaying",
                table: "Clients");
        }
    }
}
