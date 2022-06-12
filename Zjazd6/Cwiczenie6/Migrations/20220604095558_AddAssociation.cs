using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenie6.Migrations
{
    public partial class AddAssociation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPrescription",
                table: "Doctors",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.IdPrescription);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Prescription_IdPrescription",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_IdPrescription",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IdPrescription",
                table: "Doctors");
        }
    }
}
