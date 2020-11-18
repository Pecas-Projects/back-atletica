using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_Atletica.Migrations
{
    public partial class AdicionandoAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "AtleticaModalidades",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Atletas",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "AtleticaModalidades");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Atletas",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }
    }
}
