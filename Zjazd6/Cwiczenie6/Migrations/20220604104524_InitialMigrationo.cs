using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenie6.Migrations
{
    public partial class InitialMigrationo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Prescriptions_PrescriptionIdPrescription",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Prescriptions_PrescriptionIdPrescription",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PrescriptionIdPrescription",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PrescriptionIdPrescription",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "IdDoctor",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient",
                table: "Prescriptions",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "IdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "Prescriptions");

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PrescriptionIdPrescription",
                table: "Patients",
                column: "PrescriptionIdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PrescriptionIdPrescription",
                table: "Doctors",
                column: "PrescriptionIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Prescriptions_PrescriptionIdPrescription",
                table: "Doctors",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Prescriptions_PrescriptionIdPrescription",
                table: "Patients",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
