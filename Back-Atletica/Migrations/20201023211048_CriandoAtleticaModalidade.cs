using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Back_Atletica.Migrations
{
    public partial class CriandoAtleticaModalidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaCursos_Cursos_CursoId",
                table: "AtleticaCursos");

            migrationBuilder.DropTable(
                name: "AtletaModalidadeTimesEscalados");

            migrationBuilder.DropTable(
                name: "AtletaModalidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Atleta",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Membro",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "NomeCoordenador",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Duracao",
                table: "Cursos");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Pessoas",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Modalidades",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Cursos",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "CursoId");

            migrationBuilder.CreateTable(
                name: "AtleticaModalidades",
                columns: table => new
                {
                    AtleticaModalidadeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AtleticaId = table.Column<int>(nullable: false),
                    ModalidadeId = table.Column<int>(nullable: false),
                    NomeCoordenador = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtleticaModalidades", x => x.AtleticaModalidadeId);
                    table.ForeignKey(
                        name: "FK_AtleticaModalidades_Atleticas_AtleticaId",
                        column: x => x.AtleticaId,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtleticaModalidades_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "ModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtletaAtleticaModalidades",
                columns: table => new
                {
                    AtletaAtleticaModalidadeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AtletaId = table.Column<int>(nullable: false),
                    AtleticaModalidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletaAtleticaModalidades", x => x.AtletaAtleticaModalidadeId);
                    table.ForeignKey(
                        name: "FK_AtletaAtleticaModalidades_Atletas_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atletas",
                        principalColumn: "AtletaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaAtleticaModalidades_AtleticaModalidades_AtleticaModal~",
                        column: x => x.AtleticaModalidadeId,
                        principalTable: "AtleticaModalidades",
                        principalColumn: "AtleticaModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtletaAtleticaModalidadeTimesEscalados",
                columns: table => new
                {
                    AtletaAtleticaModalidadeTimeEscaladoId = table.Column<int>(nullable: false),
                    TimeEscaladoId = table.Column<int>(nullable: false),
                    AtletaAtleticaModalidadeId = table.Column<int>(nullable: false),
                    FuncaoId = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Infracoes = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletaAtleticaModalidadeTimesEscalados", x => x.AtletaAtleticaModalidadeTimeEscaladoId);
                    table.ForeignKey(
                        name: "FK_AtletaAtleticaModalidadeTimesEscalados_AtletaAtleticaModali~",
                        column: x => x.AtletaAtleticaModalidadeId,
                        principalTable: "AtletaAtleticaModalidades",
                        principalColumn: "AtletaAtleticaModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaAtleticaModalidadeTimesEscalados_Funcoes_AtletaAtleti~",
                        column: x => x.AtletaAtleticaModalidadeTimeEscaladoId,
                        principalTable: "Funcoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaAtleticaModalidadeTimesEscalados_TimeEscalados_TimeEs~",
                        column: x => x.TimeEscaladoId,
                        principalTable: "TimeEscalados",
                        principalColumn: "TimeEscaladoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtletaAtleticaModalidades_AtletaId",
                table: "AtletaAtleticaModalidades",
                column: "AtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtletaAtleticaModalidades_AtleticaModalidadeId",
                table: "AtletaAtleticaModalidades",
                column: "AtleticaModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtletaAtleticaModalidadeTimesEscalados_AtletaAtleticaModali~",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                column: "AtletaAtleticaModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtletaAtleticaModalidadeTimesEscalados_TimeEscaladoId",
                table: "AtletaAtleticaModalidadeTimesEscalados",
                column: "TimeEscaladoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidades_AtleticaId",
                table: "AtleticaModalidades",
                column: "AtleticaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidades_ModalidadeId",
                table: "AtleticaModalidades",
                column: "ModalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaCursos_Cursos_CursoId",
                table: "AtleticaCursos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaCursos_Cursos_CursoId",
                table: "AtleticaCursos");

            migrationBuilder.DropTable(
                name: "AtletaAtleticaModalidadeTimesEscalados");

            migrationBuilder.DropTable(
                name: "AtletaAtleticaModalidades");

            migrationBuilder.DropTable(
                name: "AtleticaModalidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Cursos");

            migrationBuilder.AddColumn<bool>(
                name: "Atleta",
                table: "Pessoas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Membro",
                table: "Pessoas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<char>(
                name: "Genero",
                table: "Modalidades",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AddColumn<string>(
                name: "NomeCoordenador",
                table: "Modalidades",
                type: "character varying(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Cursos",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Duracao",
                table: "Cursos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "AtletaModalidades",
                columns: table => new
                {
                    AtletaModalidadeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AtletaId = table.Column<int>(type: "integer", nullable: false),
                    ModalidadeId = table.Column<int>(type: "integer", nullable: false)
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
                    AtletaModalidadeTimeEscaladoId = table.Column<int>(type: "integer", nullable: false),
                    AtletaModalidadeId = table.Column<int>(type: "integer", nullable: false),
                    FuncaoId = table.Column<int>(type: "integer", nullable: false),
                    Infracoes = table.Column<int>(type: "integer", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Pontos = table.Column<int>(type: "integer", nullable: false),
                    TimeEscaladoId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaCursos_Cursos_CursoId",
                table: "AtleticaCursos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
