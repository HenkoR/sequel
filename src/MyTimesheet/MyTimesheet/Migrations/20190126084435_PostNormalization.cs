using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class PostNormalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Billable",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TimeEnd",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Entries",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "Project",
                table: "Entries",
                newName: "DeveloperId");

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DeveloperId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<string>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Billable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Entries",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "Entries",
                newName: "Project");

            migrationBuilder.AddColumn<bool>(
                name: "Billable",
                table: "Entries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Entries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeEnd",
                table: "Entries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "Entries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
