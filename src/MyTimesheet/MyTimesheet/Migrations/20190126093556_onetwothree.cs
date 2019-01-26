using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class onetwothree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Projects",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "Entries",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperId",
                table: "Entries",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_DeveloperId",
                table: "Entries",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ProjectId",
                table: "Entries",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Developers_DeveloperId",
                table: "Entries",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Projects_ProjectId",
                table: "Entries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Developers_DeveloperId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Projects_ProjectId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_DeveloperId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ProjectId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "Entries",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperId",
                table: "Entries",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
