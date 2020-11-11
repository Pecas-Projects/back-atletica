using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Back_Atletica.Migrations
{
    public partial class RetirandoRelacionamentos11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Produtos_ImagemId",
                table: "Imagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Publicacoes_ImagemId",
                table: "Imagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Atletas_PessoaId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Membros_PessoaId",
                table: "Pessoas");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Pessoas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "Imagens",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                name: "IX_Atletas_PessoaId",
                table: "Atletas",
                column: "PessoaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_Pessoas_PessoaId",
                table: "Atletas",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_Pessoas_PessoaId",
                table: "Atletas");

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
                name: "IX_Atletas_PessoaId",
                table: "Atletas");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Pessoas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ImagemId",
                table: "Imagens",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
        }
    }
}
