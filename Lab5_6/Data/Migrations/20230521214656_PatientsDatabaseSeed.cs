using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab5_6.Data.Migrations
{
    public partial class PatientsDatabaseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] {
                    "Id",
                    "OIB",
                    "MBO",
                    "FirstName",
                    "LastName",
                    "DateOfBirth",
                    "Gender",
                    "Diagnosis",
                    "Insurance",
                    "AdmissionDate"
                },
                values: new object[] {
                    Guid.NewGuid(),
                    "00000000000",
                    "000000000",
                    "Anamarija",
                    "Papić",
                    new DateTime(2001, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    1,
                    0,
                    0,
                    new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] {
                    "Id",
                    "OIB",
                    "MBO",
                    "FirstName",
                    "LastName",
                    "DateOfBirth",
                    "Gender",
                    "Diagnosis",
                    "Insurance",
                    "AdmissionDate",
                    "DischargeDate"
                },
                values: new object[] {
                    Guid.NewGuid(),
                    "11111111111",
                    "111111111",
                    "John",
                    "Doe",
                    new DateTime(1980, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    0,
                    1,
                    1,
                    new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] {
                    "Id",
                    "OIB",
                    "MBO",
                    "FirstName",
                    "LastName",
                    "DateOfBirth",
                    "Gender",
                    "Diagnosis",
                    "Insurance",
                    "AdmissionDate",
                    "DischargeDate"
                },
                values: new object[] {
                    Guid.NewGuid(),
                    "22222222222",
                    "222222222",
                    "Jane",
                    "Doe",
                    new DateTime(1990, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    2,
                    2,
                    2,
                    new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "OIB",
                keyValue: "00000000000");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "OIB",
                keyValue: "11111111111");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "OIB",
                keyValue: "22222222222");
        }
    }
}
