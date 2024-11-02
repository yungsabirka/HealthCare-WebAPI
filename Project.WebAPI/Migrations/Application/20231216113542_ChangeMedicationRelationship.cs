using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.WebAPI.Migrations.Application
{
    /// <inheritdoc />
    public partial class ChangeMedicationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationRelationships_MedicalCards_MedicalCardId",
                table: "MedicationRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationRelationships_Medications_MedicationId",
                table: "MedicationRelationships");

            migrationBuilder.DropIndex(
                name: "IX_MedicationRelationships_MedicalCardId",
                table: "MedicationRelationships");

            migrationBuilder.DropIndex(
                name: "IX_MedicationRelationships_MedicationId",
                table: "MedicationRelationships");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MedicationRelationships_MedicalCardId",
                table: "MedicationRelationships",
                column: "MedicalCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRelationships_MedicationId",
                table: "MedicationRelationships",
                column: "MedicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationRelationships_MedicalCards_MedicalCardId",
                table: "MedicationRelationships",
                column: "MedicalCardId",
                principalTable: "MedicalCards",
                principalColumn: "MedicalCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationRelationships_Medications_MedicationId",
                table: "MedicationRelationships",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "MedicationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
