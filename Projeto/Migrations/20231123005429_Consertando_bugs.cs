using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class Consertando_bugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cursos_categorias_CategoriasId_categoria",
                table: "cursos");

            migrationBuilder.DropIndex(
                name: "IX_cursos_CategoriasId_categoria",
                table: "cursos");

            migrationBuilder.DropColumn(
                name: "CategoriasId_categoria",
                table: "cursos");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "modulos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "modulos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriasId_categoria",
                table: "cursos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cursos_CategoriasId_categoria",
                table: "cursos",
                column: "CategoriasId_categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_cursos_categorias_CategoriasId_categoria",
                table: "cursos",
                column: "CategoriasId_categoria",
                principalTable: "categorias",
                principalColumn: "Id_categoria");
        }
    }
}
