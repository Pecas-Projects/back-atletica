using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Back_Atletica.Migrations
{
    public partial class Banco_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Duracao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Faculdades",
                columns: table => new
                {
                    FaculdadeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculdades", x => x.FaculdadeId);
                });

            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    JogoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Local = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.JogoId);
                });

            migrationBuilder.CreateTable(
                name: "Modalidades",
                columns: table => new
                {
                    ModalidadeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    NomeCoordenador = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades", x => x.ModalidadeId);
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    CampusId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FaculdadeId = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.CampusId);
                    table.ForeignKey(
                        name: "FK_Campus_Faculdades_FaculdadeId",
                        column: x => x.FaculdadeId,
                        principalTable: "Faculdades",
                        principalColumn: "FaculdadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atleticas",
                columns: table => new
                {
                    AtleticaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampusId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    PIN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atleticas", x => x.AtleticaId);
                    table.ForeignKey(
                        name: "FK_Atleticas_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtleticaCurso",
                columns: table => new
                {
                    AtleticaCursoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AtleticaId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtleticaCurso", x => x.AtleticaCursoId);
                    table.ForeignKey(
                        name: "FK_AtleticaCurso_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtleticaCurso_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Local = table.Column<string>(nullable: true),
                    DataHora = table.Column<DateTime>(nullable: false),
                    PrecoIngresso = table.Column<double>(nullable: false),
                    Categoria = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    AtleticaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Eventos_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    ImagemId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AtleticaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Extensao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.ImagemId);
                    table.ForeignKey(
                        name: "FK_Imagens_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Whatsapp = table.Column<string>(nullable: true),
                    Atleta = table.Column<bool>(nullable: false),
                    Membro = table.Column<bool>(nullable: false),
                    DataMatricula = table.Column<DateTime>(nullable: false),
                    AtleticaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Pessoas_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoAtletas",
                columns: table => new
                {
                    SolicitacaoAtletaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    WhatsApp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AtleticaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoAtletas", x => x.SolicitacaoAtletaId);
                    table.ForeignKey(
                        name: "FK_SolicitacaoAtletas_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeEscalados",
                columns: table => new
                {
                    TimeEscaladoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    AtleticaId = table.Column<int>(nullable: false),
                    JogoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeEscalados", x => x.TimeEscaladoId);
                    table.ForeignKey(
                        name: "FK_TimeEscalados_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeEscalados_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "JogoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    Estoque = table.Column<int>(nullable: false),
                    ImagemId = table.Column<int>(nullable: false),
                    AtleticaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "ImagemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicacoes",
                columns: table => new
                {
                    PublicacaoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    ImagemId = table.Column<int>(nullable: false),
                    AtleticaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacoes", x => x.PublicacaoId);
                    table.ForeignKey(
                        name: "FK_Publicacoes_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publicacoes_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "ImagemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atletas",
                columns: table => new
                {
                    AtletaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    PessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletas", x => x.AtletaId);
                    table.ForeignKey(
                        name: "FK_Atletas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    MembroId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    PessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.MembroId);
                    table.ForeignKey(
                        name: "FK_Membros_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtletaModalidades",
                columns: table => new
                {
                    AtletaModalidadeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AtletaId = table.Column<int>(nullable: false),
                    ModalidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletaModalidades", x => x.AtletaModalidadeId);
                    table.ForeignKey(
                        name: "FK_AtletaModalidades_Atletas_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atletas",
                        principalColumn: "AtletaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaModalidades_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "ModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtletaModalidadeTimesEscalados",
                columns: table => new
                {
                    AtletaModalidadeTimeEscaladoId = table.Column<int>(nullable: false),
                    TimeEscaladoId = table.Column<int>(nullable: false),
                    AtletaModalidadeId = table.Column<int>(nullable: false),
                    FuncaoId = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Infracoes = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletaModalidadeTimesEscalados", x => x.AtletaModalidadeTimeEscaladoId);
                    table.ForeignKey(
                        name: "FK_AtletaModalidadeTimesEscalados_AtletaModalidades_AtletaModa~",
                        column: x => x.AtletaModalidadeId,
                        principalTable: "AtletaModalidades",
                        principalColumn: "AtletaModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaModalidadeTimesEscalados_Funcoes_AtletaModalidadeTime~",
                        column: x => x.AtletaModalidadeTimeEscaladoId,
                        principalTable: "Funcoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaModalidadeTimesEscalados_TimeEscalados_TimeEscaladoId",
                        column: x => x.TimeEscaladoId,
                        principalTable: "TimeEscalados",
                        principalColumn: "TimeEscaladoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtletaModalidades_AtletaId",
                table: "AtletaModalidades",
                column: "AtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtletaModalidades_ModalidadeId",
                table: "AtletaModalidades",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtletaModalidadeTimesEscalados_AtletaModalidadeId",
                table: "AtletaModalidadeTimesEscalados",
                column: "AtletaModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtletaModalidadeTimesEscalados_TimeEscaladoId",
                table: "AtletaModalidadeTimesEscalados",
                column: "TimeEscaladoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_PessoaId",
                table: "Atletas",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaCurso_AtleticaId",
                table: "AtleticaCurso",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaCurso_CursoId",
                table: "AtleticaCurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atleticas_CampusId",
                table: "Atleticas",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Campus_FaculdadeId",
                table: "Campus",
                column: "FaculdadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_AtleticaId",
                table: "Eventos",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_AtleticaId",
                table: "Imagens",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Membros_PessoaId",
                table: "Membros",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_AtleticaId",
                table: "Pessoas",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_AtleticaId",
                table: "Produtos",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ImagemId",
                table: "Produtos",
                column: "ImagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_AtleticaId",
                table: "Publicacoes",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_ImagemId",
                table: "Publicacoes",
                column: "ImagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoAtletas_AtleticaId",
                table: "SolicitacaoAtletas",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEscalados_AtleticaId",
                table: "TimeEscalados",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEscalados_JogoId",
                table: "TimeEscalados",
                column: "JogoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaModalidadeTimesEscalados");

            migrationBuilder.DropTable(
                name: "AtleticaCurso");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Publicacoes");

            migrationBuilder.DropTable(
                name: "SolicitacaoAtletas");

            migrationBuilder.DropTable(
                name: "AtletaModalidades");

            migrationBuilder.DropTable(
                name: "Funcoes");

            migrationBuilder.DropTable(
                name: "TimeEscalados");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "Atletas");

            migrationBuilder.DropTable(
                name: "Modalidades");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Atleticas");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "Faculdades");
        }
    }
}
