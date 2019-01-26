using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTimesheet.Migrations
{
    public partial class newmigrations : Migration
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
                name: "nameeId",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "projectId",
                table: "Entries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    client = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    eId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.eId);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    clientId = table.Column<int>(nullable: true),
                    Project = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projects_Clients_clientId",
                        column: x => x.clientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_nameeId",
                table: "Entries",
                column: "nameeId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_projectId",
                table: "Entries",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_clientId",
                table: "projects",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Employees_nameeId",
                table: "Entries",
                column: "nameeId",
                principalTable: "Employees",
                principalColumn: "eId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_projects_projectId",
                table: "Entries",
                column: "projectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Employees_nameeId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_projects_projectId",
                table: "Entries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Entries_nameeId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_projectId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "nameeId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "projectId",
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
