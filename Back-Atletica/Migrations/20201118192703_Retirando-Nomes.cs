using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_Atletica.Migrations
{
    public partial class RetirandoNomes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "TimeEscalados");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Imagens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "TimeEscalados",
                type: "character varying(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Imagens",
                type: "character varying(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");
        }
    }
}
