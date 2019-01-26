using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class HomeworkMigration_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entries",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "Entries");

            migrationBuilder.RenameTable(
                name: "Entries",
                newName: "TimesheetEntry");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "TimesheetEntry",
                newName: "Project_ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TimesheetEntry",
                newName: "Timesheet_ID");

            migrationBuilder.AddColumn<int>(
                name: "Client_ID",
                table: "TimesheetEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dev_ID",
                table: "TimesheetEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimesheetEntry",
                table: "TimesheetEntry",
                column: "Timesheet_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimesheetEntry",
                table: "TimesheetEntry");

            migrationBuilder.DropColumn(
                name: "Client_ID",
                table: "TimesheetEntry");

            migrationBuilder.DropColumn(
                name: "Dev_ID",
                table: "TimesheetEntry");

            migrationBuilder.RenameTable(
                name: "TimesheetEntry",
                newName: "Entries");

            migrationBuilder.RenameColumn(
                name: "Project_ID",
                table: "Entries",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "Timesheet_ID",
                table: "Entries",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entries",
                table: "Entries",
                column: "Id");
        }
    }
}
