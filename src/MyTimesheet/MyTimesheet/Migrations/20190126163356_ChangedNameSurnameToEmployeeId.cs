using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class ChangedNameSurnameToEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Entries",
                newName: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Entries",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entries",
                nullable: true);
        }
    }
}
