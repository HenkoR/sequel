using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class TestAddingTableAsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TimeEnd",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "dateId",
                table: "Entries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_dateId",
                table: "Entries",
                column: "dateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Date_dateId",
                table: "Entries",
                column: "dateId",
                principalTable: "Date",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Date_dateId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_dateId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "dateId",
                table: "Entries");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Entries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Entries",
                nullable: false,
                defaultValue: 0);

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
