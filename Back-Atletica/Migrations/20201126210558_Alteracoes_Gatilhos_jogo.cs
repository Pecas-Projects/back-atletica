using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_Atletica.Migrations
{
    public partial class Alteracoes_Gatilhos_jogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PontuacaoJogo",
                table: "TimeEscalados",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RegistrouEscalacao",
                table: "TimeEscalados",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Finalizado",
                table: "Jogos",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Atleticas",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Vencedor",
                table: "AtleticaModalidadeJogos",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PontuacaoJogo",
                table: "TimeEscalados");

            migrationBuilder.DropColumn(
                name: "RegistrouEscalacao",
                table: "TimeEscalados");

            migrationBuilder.DropColumn(
                name: "Finalizado",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Atleticas");

            migrationBuilder.AlterColumn<bool>(
                name: "Vencedor",
                table: "AtleticaModalidadeJogos",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);
        }
    }
}
