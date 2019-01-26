using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class _2ndMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "Client_ID",
                table: "Entries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Employee_ID",
                table: "Entries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client_ID",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Employee_ID",
                table: "Entries");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Entries",
                nullable: true);
        }
    }
}
