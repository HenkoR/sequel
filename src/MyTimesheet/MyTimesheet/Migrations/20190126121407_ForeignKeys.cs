using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Date_dateId",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "dateId",
                table: "Entries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clientIid",
                table: "Entries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Date_dateId",
                table: "Entries",
                column: "dateId",
                principalTable: "Date",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Date_dateId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "clientIid",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "dateId",
                table: "Entries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Date_dateId",
                table: "Entries",
                column: "dateId",
                principalTable: "Date",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
