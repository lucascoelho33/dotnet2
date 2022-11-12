using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet2.Migrations
{
    public partial class FisicaEJuridica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Pessoas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Pessoas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fundacao",
                table: "Pessoas",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Pessoas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "Pessoas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Nascimento",
                table: "Pessoas",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Pessoas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Fundacao",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Nascimento",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Pessoas");
        }
    }
}
