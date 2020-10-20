using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Back_Atletica.Migrations
{
    public partial class CriandoCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoCategoriaId",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JogoCategoriaId",
                table: "Jogos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventoCategoriaId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventoCategorias",
                columns: table => new
                {
                    EventoCategoriaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoCategorias", x => x.EventoCategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "JogoCategorias",
                columns: table => new
                {
                    JogoCategoriaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogoCategorias", x => x.JogoCategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoCategorias",
                columns: table => new
                {
                    ProdutoCategoriaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoCategorias", x => x.ProdutoCategoriaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoCategoriaId",
                table: "Produtos",
                column: "ProdutoCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_JogoCategoriaId",
                table: "Jogos",
                column: "JogoCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EventoCategoriaId",
                table: "Eventos",
                column: "EventoCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoCategorias_Nome",
                table: "EventoCategorias",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JogoCategorias_Nome",
                table: "JogoCategorias",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCategorias_Nome",
                table: "ProdutoCategorias",
                column: "Nome",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_EventoCategorias_EventoCategoriaId",
                table: "Eventos",
                column: "EventoCategoriaId",
                principalTable: "EventoCategorias",
                principalColumn: "EventoCategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_JogoCategorias_JogoCategoriaId",
                table: "Jogos",
                column: "JogoCategoriaId",
                principalTable: "JogoCategorias",
                principalColumn: "JogoCategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ProdutoCategorias_ProdutoCategoriaId",
                table: "Produtos",
                column: "ProdutoCategoriaId",
                principalTable: "ProdutoCategorias",
                principalColumn: "ProdutoCategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_EventoCategorias_EventoCategoriaId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_JogoCategorias_JogoCategoriaId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ProdutoCategorias_ProdutoCategoriaId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "EventoCategorias");

            migrationBuilder.DropTable(
                name: "JogoCategorias");

            migrationBuilder.DropTable(
                name: "ProdutoCategorias");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ProdutoCategoriaId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_JogoCategoriaId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_EventoCategoriaId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "ProdutoCategoriaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "JogoCategoriaId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "EventoCategoriaId",
                table: "Eventos");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Produtos",
                type: "character varying(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Jogos",
                type: "character varying(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Eventos",
                type: "character varying(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");
        }
    }
}
