using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.Data.Migrations
{
    public partial class deper78 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HospitalVisits_PatientId",
                table: "HospitalVisits",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalVisits_Patients_PatientId",
                table: "HospitalVisits",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalVisits_Patients_PatientId",
                table: "HospitalVisits");

            migrationBuilder.DropIndex(
                name: "IX_HospitalVisits_PatientId",
                table: "HospitalVisits");
        }
    }
}
