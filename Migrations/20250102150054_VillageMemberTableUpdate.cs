using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunniNooriMasjidAPI.Migrations
{
    /// <inheritdoc />
    public partial class VillageMemberTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_name = table.Column<string>(type: "enum('Imam','President','Secretary','Treasurer','Member','Other')", nullable: false, defaultValueSql: "'Member'", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.role_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "villages",
                columns: table => new
                {
                    village_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    village_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total_population = table.Column<int>(type: "int", nullable: true),
                    area_size = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    established_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.village_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "mohallas",
                columns: table => new
                {
                    mohalla_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mohalla_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    population = table.Column<int>(type: "int", nullable: true),
                    village_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.mohalla_id);
                    table.ForeignKey(
                        name: "mohallas_ibfk_1",
                        column: x => x.village_id,
                        principalTable: "villages",
                        principalColumn: "village_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    fatherName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mobileNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    memberPic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    joiningDate = table.Column<DateTime>(type: "date", nullable: true),
                    mohalla_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "fk_mohalla_id",
                        column: x => x.mohalla_id,
                        principalTable: "mohallas",
                        principalColumn: "mohalla_id");
                    table.ForeignKey(
                        name: "fk_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "masjidgullak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CollectionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "masjidgullak_ibfk_1",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "sadqamember",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FatherName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mohalla = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MobileNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Caste = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    AddedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MemberId);
                    table.ForeignKey(
                        name: "sadqamember_ibfk_1",
                        column: x => x.AddedBy,
                        principalTable: "members",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "villagemember",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fatherName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mohalla_id = table.Column<int>(type: "int", nullable: true),
                    mobileNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    caste = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    paymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "villagemember_ibfk_1",
                        column: x => x.mohalla_id,
                        principalTable: "mohallas",
                        principalColumn: "mohalla_id");
                    table.ForeignKey(
                        name: "villagemember_ibfk_2",
                        column: x => x.id,
                        principalTable: "members",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "MemberId",
                table: "masjidgullak",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "fk_mohalla_id",
                table: "members",
                column: "mohalla_id");

            migrationBuilder.CreateIndex(
                name: "fk_role_id",
                table: "members",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "village_id",
                table: "mohallas",
                column: "village_id");

            migrationBuilder.CreateIndex(
                name: "AddedBy",
                table: "sadqamember",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "mohalla_id",
                table: "villagemember",
                column: "mohalla_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "masjidgullak");

            migrationBuilder.DropTable(
                name: "sadqamember");

            migrationBuilder.DropTable(
                name: "villagemember");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "mohallas");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "villages");
        }
    }
}
