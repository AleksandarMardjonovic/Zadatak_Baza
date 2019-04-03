using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zadatak_Baza.Migrations
{
    public partial class BazaContext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kancelarije",
                columns: table => new
                {
                    KancelarijaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivKancelarije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kancelarije", x => x.KancelarijaId);
                });

            migrationBuilder.CreateTable(
                name: "Uredjaji",
                columns: table => new
                {
                    UredjajId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivUredjaja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uredjaji", x => x.UredjajId);
                });

            migrationBuilder.CreateTable(
                name: "Osobe",
                columns: table => new
                {
                    OsobaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImeOsoba = table.Column<string>(nullable: true),
                    PrezimeOsoba = table.Column<string>(nullable: true),
                    KancelarijaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobe", x => x.OsobaId);
                    table.ForeignKey(
                        name: "FK_Osobe_Kancelarije_KancelarijaId",
                        column: x => x.KancelarijaId,
                        principalTable: "Kancelarije",
                        principalColumn: "KancelarijaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidencijaUpotrebeUredjaja",
                columns: table => new
                {
                    EvidencijaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumZaduzenjaUredjaja = table.Column<DateTime>(nullable: false),
                    DatumRazdruzenjaUredjaja = table.Column<DateTime>(nullable: true),
                    OsobaId = table.Column<long>(nullable: false),
                    UredjajId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidencijaUpotrebeUredjaja", x => x.EvidencijaId);
                    table.ForeignKey(
                        name: "FK_EvidencijaUpotrebeUredjaja_Osobe_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osobe",
                        principalColumn: "OsobaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvidencijaUpotrebeUredjaja_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "UredjajId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvidencijaUpotrebeUredjaja_OsobaId",
                table: "EvidencijaUpotrebeUredjaja",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidencijaUpotrebeUredjaja_UredjajId",
                table: "EvidencijaUpotrebeUredjaja",
                column: "UredjajId");

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_KancelarijaId",
                table: "Osobe",
                column: "KancelarijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvidencijaUpotrebeUredjaja");

            migrationBuilder.DropTable(
                name: "Osobe");

            migrationBuilder.DropTable(
                name: "Uredjaji");

            migrationBuilder.DropTable(
                name: "Kancelarije");
        }
    }
}
