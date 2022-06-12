using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenie6.Migrations
{
    public partial class InitialMigratio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Prescription_IdPrescription",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_IdPrescription",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "IdPrescription",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Prescription",
                newName: "Prescriptions");

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions",
                column: "IdPrescription");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    PrescriptionIdPrescription = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                    table.ForeignKey(
                        name: "FK_Patients_Prescriptions_PrescriptionIdPrescription",
                        column: x => x.PrescriptionIdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PrescriptionIdPrescription",
                table: "Doctors",
                column: "PrescriptionIdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PrescriptionIdPrescription",
                table: "Patients",
                column: "PrescriptionIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Prescriptions_PrescriptionIdPrescription",
                table: "Doctors",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Prescriptions_PrescriptionIdPrescription",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PrescriptionIdPrescription",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                newName: "Prescription");

            migrationBuilder.AddColumn<int>(
                name: "IdPrescription",
                table: "Doctors",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_IdPrescription",
                table: "Doctors",
                column: "IdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Prescription_IdPrescription",
                table: "Doctors",
                column: "IdPrescription",
                principalTable: "Prescription",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
