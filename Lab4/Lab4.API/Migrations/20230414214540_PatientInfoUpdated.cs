using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4.API.Migrations
{
    public partial class PatientInfoUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Diagnoses");

            migrationBuilder.AddColumn<int>(
                name: "DiagnosisId",
                table: "Patients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiagnosisId",
                table: "Patients",
                column: "DiagnosisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diagnoses_DiagnosisId",
                table: "Patients",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Diagnoses_DiagnosisId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DiagnosisId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DiagnosisId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Diagnoses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
