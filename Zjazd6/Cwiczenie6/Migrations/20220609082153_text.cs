using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenie6.Migrations
{
    public partial class text : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);
        }
    }
}
