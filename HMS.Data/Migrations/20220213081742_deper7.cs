using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Data.Migrations
{
    public partial class deper7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitStatus",
                table: "HospitalVisits");

            migrationBuilder.AddColumn<byte>(
                name: "DoctorStatus",
                table: "HospitalVisits",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "RegistrationStatus",
                table: "HospitalVisits",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "TriageStatus",
                table: "HospitalVisits",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorStatus",
                table: "HospitalVisits");

            migrationBuilder.DropColumn(
                name: "RegistrationStatus",
                table: "HospitalVisits");

            migrationBuilder.DropColumn(
                name: "TriageStatus",
                table: "HospitalVisits");

            migrationBuilder.AddColumn<byte>(
                name: "VisitStatus",
                table: "HospitalVisits",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
