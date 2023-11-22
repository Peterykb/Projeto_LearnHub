using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class Consertandoerro_cursocategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoCategorias_cursos_CursoId",
                table: "CursoCategorias");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoCategorias_cursos_CursoId",
                table: "CursoCategorias",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoCategorias_cursos_CursoId",
                table: "CursoCategorias");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoCategorias_cursos_CursoId",
                table: "CursoCategorias",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso");
        }
    }
}
