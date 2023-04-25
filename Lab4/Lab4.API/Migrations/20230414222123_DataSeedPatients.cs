using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4.API.Migrations
{
    public partial class DataSeedPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "DateOfAdmittance", "DateOfDischarge", "IsDischarged", "DiagnosisId", "FirstName", "LastName", "PatientGender", "PatientInsurance", "PatientMbo", "PatientOib" },
                values: new object[] { 1, new DateTime(2001, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, "Anamarija", "Papić", 1, 1, "111111111", "111111111111" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "DateOfAdmittance", "DateOfDischarge", "IsDischarged", "DiagnosisId", "FirstName", "LastName", "PatientGender", "PatientInsurance", "PatientMbo", "PatientOib" },
                values: new object[] { 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, "John", "Doe", 0, 0, "222222222", "22222222222" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
