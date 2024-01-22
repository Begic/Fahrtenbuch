using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fahrtenbuch.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamePasswort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passwort",
                table: "Employees",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employees",
                newName: "Passwort");
        }
    }
}
