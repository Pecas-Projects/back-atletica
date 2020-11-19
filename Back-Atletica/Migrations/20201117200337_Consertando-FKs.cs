using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Back_Atletica.Migrations
{
    public partial class ConsertandoFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtletaAtleticaModalidadeTimesEscalados_Funcoes_AtletaAtleti~",
                table: "AtletaAtleticaModalidadeTimesEscalados");

            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaModalidadeJogos_Jogos_AtleticaModalidadeId",
                table: "AtleticaModalidadeJogos");

            migrationBuilder.AlterColumn<int>(
                name: "AtletaAtleticaModalidadeTimeEscaladoId",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidadeJogos_JogoId",
                table: "AtleticaModalidadeJogos",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtletaAtleticaModalidadeTimesEscalados_FuncaoId",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                column: "FuncaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtletaAtleticaModalidadeTimesEscalados_Funcoes_FuncaoId",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                column: "FuncaoId",
                principalTable: "Funcoes",
                principalColumn: "FuncaoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaModalidadeJogos_Jogos_JogoId",
                table: "AtleticaModalidadeJogos",
                column: "JogoId",
                principalTable: "Jogos",
                principalColumn: "JogoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtletaAtleticaModalidadeTimesEscalados_Funcoes_FuncaoId",
                table: "AtletaAtleticaModalidadeTimesEscalados");

            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaModalidadeJogos_Jogos_JogoId",
                table: "AtleticaModalidadeJogos");

            migrationBuilder.DropIndex(
                name: "IX_AtleticaModalidadeJogos_JogoId",
                table: "AtleticaModalidadeJogos");

            migrationBuilder.DropIndex(
                name: "IX_AtletaAtleticaModalidadeTimesEscalados_FuncaoId",
                table: "AtletaAtleticaModalidadeTimesEscalados");

            migrationBuilder.AlterColumn<int>(
                name: "AtletaAtleticaModalidadeTimeEscaladoId",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_AtletaAtleticaModalidadeTimesEscalados_Funcoes_AtletaAtleti~",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                column: "AtletaAtleticaModalidadeTimeEscaladoId",
                principalTable: "Funcoes",
                principalColumn: "FuncaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaModalidadeJogos_Jogos_AtleticaModalidadeId",
                table: "AtleticaModalidadeJogos",
                column: "AtleticaModalidadeId",
                principalTable: "Jogos",
                principalColumn: "JogoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
