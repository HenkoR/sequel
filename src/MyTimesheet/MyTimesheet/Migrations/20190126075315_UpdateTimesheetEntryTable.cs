using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class UpdateTimesheetEntryTable : Migration
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
                name: "Project",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "personId",
                table: "Entries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_clientId",
                table: "Entries",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_personId",
                table: "Entries",
                column: "personId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Client_clientId",
                table: "Entries",
                column: "clientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Person_personId",
                table: "Entries",
                column: "personId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Client_clientId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Person_personId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_clientId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_personId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "personId",
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
                name: "Project",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Entries",
                nullable: true);
        }
    }
}
