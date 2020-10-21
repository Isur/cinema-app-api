using Microsoft.EntityFrameworkCore.Migrations;

namespace cinema_app_api.Migrations
{
    public partial class ticketFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldX",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FieldY",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldX",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FieldY",
                table: "Tickets");
        }
    }
}
