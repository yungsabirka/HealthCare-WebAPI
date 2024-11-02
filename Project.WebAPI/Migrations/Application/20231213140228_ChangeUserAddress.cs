using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.WebAPI.Migrations.Application
{
    /// <inheritdoc />
    public partial class ChangeUserAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Users",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "Adress");
        }
    }
}
