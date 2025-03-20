using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFinder.Migrations
{
    /// <inheritdoc />
    public partial class IsFound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LostCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileStream = table.Column<byte>(type: "tinyint", nullable: false),
                    IsFound = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
