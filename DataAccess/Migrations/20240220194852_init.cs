using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kurser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skolor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skolor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elever",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkolaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elever", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elever_Skolor_SkolaId",
                        column: x => x.SkolaId,
                        principalTable: "Skolor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KursSkola",
                columns: table => new
                {
                    KurserId = table.Column<int>(type: "int", nullable: false),
                    SkolorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursSkola", x => new { x.KurserId, x.SkolorId });
                    table.ForeignKey(
                        name: "FK_KursSkola_Kurser_KurserId",
                        column: x => x.KurserId,
                        principalTable: "Kurser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursSkola_Skolor_SkolorId",
                        column: x => x.SkolorId,
                        principalTable: "Skolor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElevKurs",
                columns: table => new
                {
                    EleverId = table.Column<int>(type: "int", nullable: false),
                    KurserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevKurs", x => new { x.EleverId, x.KurserId });
                    table.ForeignKey(
                        name: "FK_ElevKurs_Elever_EleverId",
                        column: x => x.EleverId,
                        principalTable: "Elever",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElevKurs_Kurser_KurserId",
                        column: x => x.KurserId,
                        principalTable: "Kurser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElevKurs_KurserId",
                table: "ElevKurs",
                column: "KurserId");

            migrationBuilder.CreateIndex(
                name: "IX_Elever_SkolaId",
                table: "Elever",
                column: "SkolaId");

            migrationBuilder.CreateIndex(
                name: "IX_KursSkola_SkolorId",
                table: "KursSkola",
                column: "SkolorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElevKurs");

            migrationBuilder.DropTable(
                name: "KursSkola");

            migrationBuilder.DropTable(
                name: "Elever");

            migrationBuilder.DropTable(
                name: "Kurser");

            migrationBuilder.DropTable(
                name: "Skolor");
        }
    }
}
