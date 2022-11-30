using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mulakat.Migrations
{
    /// <inheritdoc />
    public partial class mulakat1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musteris",
                columns: table => new
                {
                    MusteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteris", x => x.MusteriID);
                });

            migrationBuilder.CreateTable(
                name: "Sepets",
                columns: table => new
                {
                    SepetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepets", x => x.SepetID);
                    table.ForeignKey(
                        name: "FK_Sepets_Musteris_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "Musteris",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SepetUruns",
                columns: table => new
                {
                    SepetUrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tutar = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SepetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepetUruns", x => x.SepetUrunID);
                    table.ForeignKey(
                        name: "FK_SepetUruns_Sepets_SepetID",
                        column: x => x.SepetID,
                        principalTable: "Sepets",
                        principalColumn: "SepetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sepets_MusteriID",
                table: "Sepets",
                column: "MusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_SepetUruns_SepetID",
                table: "SepetUruns",
                column: "SepetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SepetUruns");

            migrationBuilder.DropTable(
                name: "Sepets");

            migrationBuilder.DropTable(
                name: "Musteris");
        }
    }
}
