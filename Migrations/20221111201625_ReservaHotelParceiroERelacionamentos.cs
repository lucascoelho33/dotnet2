using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet2.Migrations
{
    public partial class ReservaHotelParceiroERelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoPessoa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Atividade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FisicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parceiros_Pessoas_FisicaId",
                        column: x => x.FisicaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReservaHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroReserva = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHotels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JuridicaParceiro",
                columns: table => new
                {
                    JuridicasId = table.Column<int>(type: "int", nullable: false),
                    ParceirosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridicaParceiro", x => new { x.JuridicasId, x.ParceirosId });
                    table.ForeignKey(
                        name: "FK_JuridicaParceiro_Parceiros_ParceirosId",
                        column: x => x.ParceirosId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuridicaParceiro_Pessoas_JuridicasId",
                        column: x => x.JuridicasId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FisicaReservaHotel",
                columns: table => new
                {
                    FisicasId = table.Column<int>(type: "int", nullable: false),
                    ReservaHotelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FisicaReservaHotel", x => new { x.FisicasId, x.ReservaHotelsId });
                    table.ForeignKey(
                        name: "FK_FisicaReservaHotel_Pessoas_FisicasId",
                        column: x => x.FisicasId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FisicaReservaHotel_ReservaHotels_ReservaHotelsId",
                        column: x => x.ReservaHotelsId,
                        principalTable: "ReservaHotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FisicaReservaHotel_ReservaHotelsId",
                table: "FisicaReservaHotel",
                column: "ReservaHotelsId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridicaParceiro_ParceirosId",
                table: "JuridicaParceiro",
                column: "ParceirosId");

            migrationBuilder.CreateIndex(
                name: "IX_Parceiros_FisicaId",
                table: "Parceiros",
                column: "FisicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FisicaReservaHotel");

            migrationBuilder.DropTable(
                name: "JuridicaParceiro");

            migrationBuilder.DropTable(
                name: "ReservaHotels");

            migrationBuilder.DropTable(
                name: "Parceiros");
        }
    }
}
