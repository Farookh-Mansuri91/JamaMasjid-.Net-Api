using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunniNooriMasjidAPI.Migrations
{
    /// <inheritdoc />
    public partial class imamhistoryAndMembertabeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "members",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "members");
        }
    }
}
