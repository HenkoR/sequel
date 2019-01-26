using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class EmpReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpID",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesheetEntryId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Entries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Team = table.Column<string>(nullable: true),
                    TimesheetEntryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employee_Entries_TimesheetEntryId",
                        column: x => x.TimesheetEntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmpID",
                table: "Projects",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TimesheetEntryId",
                table: "Projects",
                column: "TimesheetEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TimesheetEntryId",
                table: "Employee",
                column: "TimesheetEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employee_EmpID",
                table: "Projects",
                column: "EmpID",
                principalTable: "Employee",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Entries_TimesheetEntryId",
                table: "Projects",
                column: "TimesheetEntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employee_EmpID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Entries_TimesheetEntryId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EmpID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TimesheetEntryId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmpID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TimesheetEntryId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Entries");
        }
    }
}
