using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4.API.Migrations
{
    public partial class DataSeedDiagnoses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "Određene infekcijske i parazitske bolesti", "A00-B99" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "Neoplazme", "C00-D48" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 3, "Bolesti krvi i krvotvornih organa i određeni poremećaji imunološkog sustava", "C50-D89" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 4, "Endokrine, nutricijske i metaboličke bolesti", "E00-E90" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 5, "Mentalni poremećaji i poremećaji ponašanja", "F00-F99" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 6, "Bolesti živčanog sustava", "G00-G99" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 7, "Bolesti oka i adneksa", "H00-H59" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 8, "Bolesti uha i mastoidnih procesa", "H60-H95" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 9, "Bolesti cirkulacijskog (krvožilnog) sustava", "I00-I99" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 10, "Bolesti dišnog (respiracijskog) sustava", "J00-J99" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
