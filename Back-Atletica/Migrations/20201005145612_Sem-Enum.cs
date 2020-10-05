using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_Atletica.Migrations
{
    public partial class SemEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaCurso_Atleticas_AtleticaId",
                table: "AtleticaCurso");

            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaCurso_Cursos_CursoId",
                table: "AtleticaCurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtleticaCurso",
                table: "AtleticaCurso");

            migrationBuilder.RenameTable(
                name: "AtleticaCurso",
                newName: "AtleticaCursos");

            migrationBuilder.RenameIndex(
                name: "IX_AtleticaCurso_CursoId",
                table: "AtleticaCursos",
                newName: "IX_AtleticaCursos_CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_AtleticaCurso_AtleticaId",
                table: "AtleticaCursos",
                newName: "IX_AtleticaCursos_AtleticaId");

            migrationBuilder.AlterColumn<char>(
                name: "Genero",
                table: "Pessoas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<char>(
                name: "Genero",
                table: "Modalidades",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtleticaCursos",
                table: "AtleticaCursos",
                column: "AtleticaCursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaCursos_Atleticas_AtleticaId",
                table: "AtleticaCursos",
                column: "AtleticaId",
                principalTable: "Atleticas",
                principalColumn: "AtleticaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaCursos_Cursos_CursoId",
                table: "AtleticaCursos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaCursos_Atleticas_AtleticaId",
                table: "AtleticaCursos");

            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaCursos_Cursos_CursoId",
                table: "AtleticaCursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtleticaCursos",
                table: "AtleticaCursos");

            migrationBuilder.RenameTable(
                name: "AtleticaCursos",
                newName: "AtleticaCurso");

            migrationBuilder.RenameIndex(
                name: "IX_AtleticaCursos_CursoId",
                table: "AtleticaCurso",
                newName: "IX_AtleticaCurso_CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_AtleticaCursos_AtleticaId",
                table: "AtleticaCurso",
                newName: "IX_AtleticaCurso_AtleticaId");

            migrationBuilder.AlterColumn<int>(
                name: "Genero",
                table: "Pessoas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(char));

            migrationBuilder.AlterColumn<int>(
                name: "Genero",
                table: "Modalidades",
                type: "integer",
                nullable: false,
                oldClrType: typeof(char));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtleticaCurso",
                table: "AtleticaCurso",
                column: "AtleticaCursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaCurso_Atleticas_AtleticaId",
                table: "AtleticaCurso",
                column: "AtleticaId",
                principalTable: "Atleticas",
                principalColumn: "AtleticaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaCurso_Cursos_CursoId",
                table: "AtleticaCurso",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
