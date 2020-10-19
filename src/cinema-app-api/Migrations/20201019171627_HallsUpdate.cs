using Microsoft.EntityFrameworkCore.Migrations;

namespace cinema_app_api.Migrations
{
    public partial class HallsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Space",
                table: "Halls");

            migrationBuilder.AddColumn<int>(
                name: "SizeX",
                table: "Halls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeY",
                table: "Halls",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeX",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "SizeY",
                table: "Halls");

            migrationBuilder.AddColumn<int>(
                name: "Space",
                table: "Halls",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
