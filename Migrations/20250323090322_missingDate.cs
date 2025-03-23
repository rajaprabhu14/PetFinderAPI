using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFinder.Migrations
{
    /// <inheritdoc />
    public partial class missingDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MissingSince",
                table: "Pets",
                newName: "MissingDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MissingDate",
                table: "Pets",
                newName: "MissingSince");
        }
    }
}
