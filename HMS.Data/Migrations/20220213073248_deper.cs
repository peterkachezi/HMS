using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Data.Migrations
{
    public partial class deper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitCode",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationCode",
                table: "Patients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationCode",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "VisitCode",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
