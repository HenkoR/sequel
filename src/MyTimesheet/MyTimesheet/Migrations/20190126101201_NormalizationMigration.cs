using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class NormalizationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Billable",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TimeEnd",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "Entries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Billable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    projectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clients_projects_projectId",
                        column: x => x.projectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_clientId",
                table: "Entries",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_projectId",
                table: "clients",
                column: "projectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_clients_clientId",
                table: "Entries",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_clients_clientId",
                table: "Entries");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropIndex(
                name: "IX_Entries_clientId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "Entries");

            migrationBuilder.AddColumn<bool>(
                name: "Billable",
                table: "Entries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Entries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                name: "Project",
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
