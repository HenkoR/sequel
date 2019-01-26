using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class normalized : Migration
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
                name: "EmployeeId",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Entries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_EmployeeId",
                table: "Entries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ProjectId",
                table: "Entries",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Employees_EmployeeId",
                table: "Entries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Projects_ProjectId",
                table: "Entries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Employees_EmployeeId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Projects_ProjectId",
                table: "Entries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Entries_EmployeeId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ProjectId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ProjectId",
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
