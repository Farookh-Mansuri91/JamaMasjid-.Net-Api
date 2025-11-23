using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunniNooriMasjidAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserIdToMemberId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "villagemember",
                newName: "member_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "member_id",
                table: "villagemember",
                newName: "user_id");
        }
    }
}
