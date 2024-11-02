using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.WebAPI.Migrations.Application
{
    /// <inheritdoc />
    public partial class ChangeAppointmentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppoitmentId",
                table: "AppointmentRelationships",
                newName: "AppointmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "AppointmentRelationships",
                newName: "AppoitmentId");
        }
    }
}
