using Microsoft.EntityFrameworkCore.Migrations;


namespace Back_Atletica.Migrations
{
    public partial class Aprovacao_Solicitacao_Atleta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aprovado",
                table: "SolicitacaoAtletas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprovado",
                table: "SolicitacaoAtletas");
        }
    }
}
