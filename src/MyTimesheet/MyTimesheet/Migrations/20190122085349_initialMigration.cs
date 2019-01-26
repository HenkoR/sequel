using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Billable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });

            migrationBuilder.Sql(
                @"
                UPDATE Entries
                SET Name = Name + ' ' + Surname;");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Entries");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Billable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });

            migrationBuilder.DropColumn(
                    name: "Client",
                    table: "Entries");

            migrationBuilder.DropColumn(
                    name: "Project",
                    table: "Entries");

            migrationBuilder.DropColumn(
                    name: "Description",
                    table: "Entries");

            migrationBuilder.DropColumn(
                    name: "Billable",
                    table: "Entries");

            migrationBuilder.DropColumn(
                    name: "Date",
                    table: "Entries");

            migrationBuilder.DropColumn(
                    name: "TimeStart",
                    table: "Entries");

            migrationBuilder.DropColumn(
                    name: "TimeEnd",
                    table: "Entries");

            migrationBuilder.DropColumn(
                    name: "Duration",
                    table: "Entries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
