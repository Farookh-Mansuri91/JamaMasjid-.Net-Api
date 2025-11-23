using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunniNooriMasjidAPI.Migrations
{
    /// <inheritdoc />
    public partial class imamhistoryAndMembertabeUpdatetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role_type",
                table: "roles",
                type: "enum('Special', 'Normal')",
                nullable: false,
                defaultValue: "Normal",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role_type",
                table: "roles");
        }
    }
}
