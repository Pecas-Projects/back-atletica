using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Back_Atletica.Migrations
{
    public partial class NullConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaModalidades_Imagens_ImagemId",
                table: "AtleticaModalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaModalidades_Membros_MembroId",
                table: "AtleticaModalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Atleticas_Campus_CampusId",
                table: "Atleticas");

            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Imagens_ImagemId",
                table: "Membros");

            migrationBuilder.DropTable(
                name: "AtleticaModalidadeAgendaTreinos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Funcoes");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "SolicitacaoJogos",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnoEntradaFacul",
                table: "SolicitacaoAtletas",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<char>(
                name: "Genero",
                table: "SolicitacaoAtletas",
                nullable: false,
                defaultValue: 'I');

            migrationBuilder.AlterColumn<char>(
                name: "Genero",
                table: "Pessoas",
                nullable: false,
                defaultValue: 'I',
                oldClrType: typeof(char),
                oldType: "character(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnoEntradaFacul",
                table: "Pessoas",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "Membros",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "JogoCategorias",
                type: "CHAR(7)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PrecoIngresso",
                table: "Eventos",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "EventoCategorias",
                type: "CHAR(7)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CampusId",
                table: "Atleticas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PosicaoRanking",
                table: "AtleticaModalidades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MembroId",
                table: "AtleticaModalidades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "AtleticaModalidades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "Vencedor",
                table: "AtleticaModalidadeJogos",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Pontos",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Infracoes",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FuncaoId",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraInicio",
                table: "AgendaTreinos",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<string>(
                name: "DiaSemana",
                table: "AgendaTreinos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AtleticaModalidadeId",
                table: "AgendaTreinos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AgendaTreinos_AtleticaModalidadeId",
                table: "AgendaTreinos",
                column: "AtleticaModalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendaTreinos_AtleticaModalidades_AtleticaModalidadeId",
                table: "AgendaTreinos",
                column: "AtleticaModalidadeId",
                principalTable: "AtleticaModalidades",
                principalColumn: "AtleticaModalidadeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaModalidades_Imagens_ImagemId",
                table: "AtleticaModalidades",
                column: "ImagemId",
                principalTable: "Imagens",
                principalColumn: "ImagemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaModalidades_Membros_MembroId",
                table: "AtleticaModalidades",
                column: "MembroId",
                principalTable: "Membros",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atleticas_Campus_CampusId",
                table: "Atleticas",
                column: "CampusId",
                principalTable: "Campus",
                principalColumn: "CampusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Imagens_ImagemId",
                table: "Membros",
                column: "ImagemId",
                principalTable: "Imagens",
                principalColumn: "ImagemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendaTreinos_AtleticaModalidades_AtleticaModalidadeId",
                table: "AgendaTreinos");

            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaModalidades_Imagens_ImagemId",
                table: "AtleticaModalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaModalidades_Membros_MembroId",
                table: "AtleticaModalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Atleticas_Campus_CampusId",
                table: "Atleticas");

            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Imagens_ImagemId",
                table: "Membros");

            migrationBuilder.DropIndex(
                name: "IX_AgendaTreinos_AtleticaModalidadeId",
                table: "AgendaTreinos");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "SolicitacaoAtletas");

            migrationBuilder.DropColumn(
                name: "AtleticaModalidadeId",
                table: "AgendaTreinos");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "SolicitacaoJogos",
                type: "character varying(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnoEntradaFacul",
                table: "SolicitacaoAtletas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<char>(
                name: "Genero",
                table: "Pessoas",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(char),
                oldDefaultValue: 'I');

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnoEntradaFacul",
                table: "Pessoas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "Membros",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "JogoCategorias",
                type: "character varying(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(7)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Funcoes",
                type: "character varying(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PrecoIngresso",
                table: "Eventos",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "EventoCategorias",
                type: "character varying(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CampusId",
                table: "Atleticas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PosicaoRanking",
                table: "AtleticaModalidades",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MembroId",
                table: "AtleticaModalidades",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "AtleticaModalidades",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Vencedor",
                table: "AtleticaModalidadeJogos",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Pontos",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Infracoes",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuncaoId",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraInicio",
                table: "AgendaTreinos",
                type: "interval",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaSemana",
                table: "AgendaTreinos",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "AtleticaModalidadeAgendaTreinos",
                columns: table => new
                {
                    AtleticaModalidadeAgendaTreinoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgendaTreinoId = table.Column<int>(type: "integer", nullable: false),
                    AtleticaModalidadeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtleticaModalidadeAgendaTreinos", x => x.AtleticaModalidadeAgendaTreinoId);
                    table.ForeignKey(
                        name: "FK_AtleticaModalidadeAgendaTreinos_AgendaTreinos_AgendaTreinoId",
                        column: x => x.AgendaTreinoId,
                        principalTable: "AgendaTreinos",
                        principalColumn: "AgendaTreinoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtleticaModalidadeAgendaTreinos_AtleticaModalidades_Atletic~",
                        column: x => x.AtleticaModalidadeId,
                        principalTable: "AtleticaModalidades",
                        principalColumn: "AtleticaModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidadeAgendaTreinos_AgendaTreinoId",
                table: "AtleticaModalidadeAgendaTreinos",
                column: "AgendaTreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidadeAgendaTreinos_AtleticaModalidadeId",
                table: "AtleticaModalidadeAgendaTreinos",
                column: "AtleticaModalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaModalidades_Imagens_ImagemId",
                table: "AtleticaModalidades",
                column: "ImagemId",
                principalTable: "Imagens",
                principalColumn: "ImagemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaModalidades_Membros_MembroId",
                table: "AtleticaModalidades",
                column: "MembroId",
                principalTable: "Membros",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atleticas_Campus_CampusId",
                table: "Atleticas",
                column: "CampusId",
                principalTable: "Campus",
                principalColumn: "CampusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Imagens_ImagemId",
                table: "Membros",
                column: "ImagemId",
                principalTable: "Imagens",
                principalColumn: "ImagemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
