using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Back_Atletica.Migrations
{
    public partial class LogicaGrafos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtletaAtleticaModalidadeTimesEscalados_Funcoes_AtletaAtleti~",
                table: "AtletaAtleticaModalidadeTimesEscalados");

            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_Pessoas_PessoaId",
                table: "Atletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Atleticas_AtleticaId",
                table: "Imagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Pessoas_PessoaId",
                table: "Membros");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Imagens_ImagemId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Imagens_ImagemId",
                table: "Publicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Publicacoes_ImagemId",
                table: "Publicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ImagemId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Membros_PessoaId",
                table: "Membros");

            migrationBuilder.DropIndex(
                name: "IX_Imagens_AtleticaId",
                table: "Imagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcoes",
                table: "Funcoes");

            migrationBuilder.DropIndex(
                name: "IX_Atletas_PessoaId",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "DataMatricula",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "AtleticaId",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Funcoes");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Eventos");

            migrationBuilder.AddColumn<DateTime>(
                name: "AnoEntradaFacul",
                table: "SolicitacaoAtletas",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "SolicitacaoAtletas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Pessoas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnoEntradaFacul",
                table: "Pessoas",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Pessoas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImagemId",
                table: "Membros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "JogoCategorias",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "Imagens",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "FuncaoId",
                table: "Funcoes",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "EventoCategorias",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkProsel",
                table: "Atleticas",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Atleticas",
                maxLength: 17,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImagemId",
                table: "AtleticaModalidades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosicaoRanking",
                table: "AtleticaModalidades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcoes",
                table: "Funcoes",
                column: "FuncaoId");

            migrationBuilder.CreateTable(
                name: "AgendaTreinos",
                columns: table => new
                {
                    AgendaTreinoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiaSemana = table.Column<string>(maxLength: 30, nullable: true),
                    HoraInicio = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaTreinos", x => x.AgendaTreinoId);
                });

            migrationBuilder.CreateTable(
                name: "AtleticaModalidadeJogos",
                columns: table => new
                {
                    AtleticaModalidadeJogoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Vencedor = table.Column<bool>(nullable: false),
                    AtleticaModalidadeId = table.Column<int>(nullable: false),
                    JogoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtleticaModalidadeJogos", x => x.AtleticaModalidadeJogoId);
                    table.ForeignKey(
                        name: "FK_AtleticaModalidadeJogos_AtleticaModalidades_AtleticaModalid~",
                        column: x => x.AtleticaModalidadeId,
                        principalTable: "AtleticaModalidades",
                        principalColumn: "AtleticaModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtleticaModalidadeJogos_Jogos_AtleticaModalidadeId",
                        column: x => x.AtleticaModalidadeId,
                        principalTable: "Jogos",
                        principalColumn: "JogoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagemAtleticas",
                columns: table => new
                {
                    ImagemAtleticaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<char>(nullable: false),
                    ImagemId = table.Column<int>(nullable: false),
                    AtleticaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemAtleticas", x => x.ImagemAtleticaId);
                    table.ForeignKey(
                        name: "FK_ImagemAtleticas_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImagemAtleticas_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "ImagemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoAtletaModalidades",
                columns: table => new
                {
                    SolicitacaoAtletaModalidadeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SolicitacaoAtletaId = table.Column<int>(nullable: false),
                    ModalidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoAtletaModalidades", x => x.SolicitacaoAtletaModalidadeId);
                    table.ForeignKey(
                        name: "FK_SolicitacaoAtletaModalidades_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "ModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoAtletaModalidades_SolicitacaoAtletas_Solicitacao~",
                        column: x => x.SolicitacaoAtletaId,
                        principalTable: "SolicitacaoAtletas",
                        principalColumn: "SolicitacaoAtletaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoJogos",
                columns: table => new
                {
                    SolicitacaoJogoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Aprovado = table.Column<bool>(nullable: false),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Local = table.Column<string>(maxLength: 45, nullable: true),
                    AtleticaId = table.Column<int>(nullable: false),
                    AtleticaAdversariaId = table.Column<int>(nullable: false),
                    JogoCategoriaId = table.Column<int>(nullable: false),
                    ModalidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoJogos", x => x.SolicitacaoJogoId);
                    table.ForeignKey(
                        name: "FK_SolicitacaoJogos_Atleticas_AtleticaAdversariaId",
                        column: x => x.AtleticaAdversariaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoJogos_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoJogos_JogoCategorias_JogoCategoriaId",
                        column: x => x.JogoCategoriaId,
                        principalTable: "JogoCategorias",
                        principalColumn: "JogoCategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoJogos_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "ModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtleticaModalidadeAgendaTreinos",
                columns: table => new
                {
                    AtleticaModalidadeAgendaTreinoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AtleticaModalidadeId = table.Column<int>(nullable: false),
                    AgendaTreinoId = table.Column<int>(nullable: false)
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
                name: "IX_SolicitacaoAtletas_CursoId",
                table: "SolicitacaoAtletas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CursoId",
                table: "Pessoas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Membros_ImagemId",
                table: "Membros",
                column: "ImagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidades_ImagemId",
                table: "AtleticaModalidades",
                column: "ImagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidadeAgendaTreinos_AgendaTreinoId",
                table: "AtleticaModalidadeAgendaTreinos",
                column: "AgendaTreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidadeAgendaTreinos_AtleticaModalidadeId",
                table: "AtleticaModalidadeAgendaTreinos",
                column: "AtleticaModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidadeJogos_AtleticaModalidadeId",
                table: "AtleticaModalidadeJogos",
                column: "AtleticaModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemAtleticas_AtleticaId",
                table: "ImagemAtleticas",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemAtleticas_ImagemId",
                table: "ImagemAtleticas",
                column: "ImagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoAtletaModalidades_ModalidadeId",
                table: "SolicitacaoAtletaModalidades",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoAtletaModalidades_SolicitacaoAtletaId",
                table: "SolicitacaoAtletaModalidades",
                column: "SolicitacaoAtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoJogos_AtleticaAdversariaId",
                table: "SolicitacaoJogos",
                column: "AtleticaAdversariaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoJogos_AtleticaId",
                table: "SolicitacaoJogos",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoJogos_JogoCategoriaId",
                table: "SolicitacaoJogos",
                column: "JogoCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoJogos_ModalidadeId",
                table: "SolicitacaoJogos",
                column: "ModalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtletaAtleticaModalidadeTimesEscalados_Funcoes_AtletaAtleti~",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                column: "AtletaAtleticaModalidadeTimeEscaladoId",
                principalTable: "Funcoes",
                principalColumn: "FuncaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaModalidades_Imagens_ImagemId",
                table: "AtleticaModalidades",
                column: "ImagemId",
                principalTable: "Imagens",
                principalColumn: "ImagemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Produtos_ImagemId",
                table: "Imagens",
                column: "ImagemId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Publicacoes_ImagemId",
                table: "Imagens",
                column: "ImagemId",
                principalTable: "Publicacoes",
                principalColumn: "PublicacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Imagens_ImagemId",
                table: "Membros",
                column: "ImagemId",
                principalTable: "Imagens",
                principalColumn: "ImagemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cursos_CursoId",
                table: "Pessoas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Atletas_PessoaId",
                table: "Pessoas",
                column: "PessoaId",
                principalTable: "Atletas",
                principalColumn: "AtletaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Membros_PessoaId",
                table: "Pessoas",
                column: "PessoaId",
                principalTable: "Membros",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoAtletas_Cursos_CursoId",
                table: "SolicitacaoAtletas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtletaAtleticaModalidadeTimesEscalados_Funcoes_AtletaAtleti~",
                table: "AtletaAtleticaModalidadeTimesEscalados");

            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaModalidades_Imagens_ImagemId",
                table: "AtleticaModalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Produtos_ImagemId",
                table: "Imagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Publicacoes_ImagemId",
                table: "Imagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Imagens_ImagemId",
                table: "Membros");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cursos_CursoId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Atletas_PessoaId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Membros_PessoaId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoAtletas_Cursos_CursoId",
                table: "SolicitacaoAtletas");

            migrationBuilder.DropTable(
                name: "AtleticaModalidadeAgendaTreinos");

            migrationBuilder.DropTable(
                name: "AtleticaModalidadeJogos");

            migrationBuilder.DropTable(
                name: "ImagemAtleticas");

            migrationBuilder.DropTable(
                name: "SolicitacaoAtletaModalidades");

            migrationBuilder.DropTable(
                name: "SolicitacaoJogos");

            migrationBuilder.DropTable(
                name: "AgendaTreinos");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoAtletas_CursoId",
                table: "SolicitacaoAtletas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_CursoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Membros_ImagemId",
                table: "Membros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcoes",
                table: "Funcoes");

            migrationBuilder.DropIndex(
                name: "IX_AtleticaModalidades_ImagemId",
                table: "AtleticaModalidades");

            migrationBuilder.DropColumn(
                name: "AnoEntradaFacul",
                table: "SolicitacaoAtletas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "SolicitacaoAtletas");

            migrationBuilder.DropColumn(
                name: "AnoEntradaFacul",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ImagemId",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "JogoCategorias");

            migrationBuilder.DropColumn(
                name: "FuncaoId",
                table: "Funcoes");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "EventoCategorias");

            migrationBuilder.DropColumn(
                name: "LinkProsel",
                table: "Atleticas");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Atleticas");

            migrationBuilder.DropColumn(
                name: "ImagemId",
                table: "AtleticaModalidades");

            migrationBuilder.DropColumn(
                name: "PosicaoRanking",
                table: "AtleticaModalidades");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Pessoas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMatricula",
                table: "Pessoas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Jogos",
                type: "character varying(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "Imagens",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "AtleticaId",
                table: "Imagens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Funcoes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Eventos",
                type: "character varying(7)",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcoes",
                table: "Funcoes",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_ImagemId",
                table: "Publicacoes",
                column: "ImagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ImagemId",
                table: "Produtos",
                column: "ImagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membros_PessoaId",
                table: "Membros",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_AtleticaId",
                table: "Imagens",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_PessoaId",
                table: "Atletas",
                column: "PessoaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AtletaAtleticaModalidadeTimesEscalados_Funcoes_AtletaAtleti~",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                column: "AtletaAtleticaModalidadeTimeEscaladoId",
                principalTable: "Funcoes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_Pessoas_PessoaId",
                table: "Atletas",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Atleticas_AtleticaId",
                table: "Imagens",
                column: "AtleticaId",
                principalTable: "Atleticas",
                principalColumn: "AtleticaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Pessoas_PessoaId",
                table: "Membros",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Imagens_ImagemId",
                table: "Produtos",
                column: "ImagemId",
                principalTable: "Imagens",
                principalColumn: "ImagemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Imagens_ImagemId",
                table: "Publicacoes",
                column: "ImagemId",
                principalTable: "Imagens",
                principalColumn: "ImagemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
