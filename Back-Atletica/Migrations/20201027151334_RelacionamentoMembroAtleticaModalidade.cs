using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_Atletica.Migrations
{
    public partial class RelacionamentoMembroAtleticaModalidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCoordenador",
                table: "AtleticaModalidades");

            migrationBuilder.AddColumn<int>(
                name: "MembroId",
                table: "AtleticaModalidades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AtleticaModalidades_MembroId",
                table: "AtleticaModalidades",
                column: "MembroId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtleticaModalidades_Membros_MembroId",
                table: "AtleticaModalidades",
                column: "MembroId",
                principalTable: "Membros",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtleticaModalidades_Membros_MembroId",
                table: "AtleticaModalidades");

            migrationBuilder.DropIndex(
                name: "IX_AtleticaModalidades_MembroId",
                table: "AtleticaModalidades");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "AtleticaModalidades");

            migrationBuilder.AddColumn<string>(
                name: "NomeCoordenador",
                table: "AtleticaModalidades",
                type: "character varying(45)",
                maxLength: 45,
                nullable: true);
        }
    }
}
