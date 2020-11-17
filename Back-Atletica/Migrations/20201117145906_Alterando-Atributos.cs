using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_Atletica.Migrations
{
    public partial class AlterandoAtributos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                table: "Publicacoes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "Estoque",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Imagens",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "AtletaAtleticaModalidades",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "Publicacoes");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "AtletaAtleticaModalidades");

            migrationBuilder.AlterColumn<int>(
                name: "Estoque",
                table: "Produtos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
