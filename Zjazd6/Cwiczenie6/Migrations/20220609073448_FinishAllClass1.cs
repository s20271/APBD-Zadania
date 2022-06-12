using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenie6.Migrations
{
    public partial class FinishAllClass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_Medicament_IdMedicament",
                table: "Prescription_Medicament");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_IdMedicament",
                table: "Prescription_Medicament");

            migrationBuilder.AddColumn<int>(
                name: "MedicamentIdMedicament",
                table: "Prescription_Medicament",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "Prescription_Medicament",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_MedicamentIdMedicament",
                table: "Prescription_Medicament",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_PrescriptionIdPrescription",
                table: "Prescription_Medicament",
                column: "PrescriptionIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_Medicament_MedicamentIdMedicament",
                table: "Prescription_Medicament",
                column: "MedicamentIdMedicament",
                principalTable: "Medicament",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_PrescriptionIdPrescription",
                table: "Prescription_Medicament",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_Medicament_MedicamentIdMedicament",
                table: "Prescription_Medicament");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_PrescriptionIdPrescription",
                table: "Prescription_Medicament");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicament_MedicamentIdMedicament",
                table: "Prescription_Medicament");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicament_PrescriptionIdPrescription",
                table: "Prescription_Medicament");

            migrationBuilder.DropColumn(
                name: "MedicamentIdMedicament",
                table: "Prescription_Medicament");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "Prescription_Medicament");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_Medicament_IdMedicament",
                table: "Prescription_Medicament",
                column: "IdMedicament",
                principalTable: "Medicament",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_IdMedicament",
                table: "Prescription_Medicament",
                column: "IdMedicament",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
