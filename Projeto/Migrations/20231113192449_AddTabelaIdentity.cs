using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelaIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aulas_cursos_Id_curso",
                table: "aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_cursos_categorias_Id_categoria",
                table: "cursos");

            migrationBuilder.DropIndex(
                name: "IX_cursos_Id_categoria",
                table: "cursos");

            migrationBuilder.DropIndex(
                name: "IX_aulas_Id_curso",
                table: "aulas");

            migrationBuilder.DropColumn(
                name: "Id_categoria",
                table: "cursos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "alunos");

            migrationBuilder.DropColumn(
                name: "Id_curso",
                table: "alunos");

            migrationBuilder.RenameColumn(
                name: "Pass",
                table: "instrutors",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "Pass",
                table: "alunos",
                newName: "CPF");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "instrutors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CursoId_curso",
                table: "aulas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "alunos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CursoCategorias",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoCategorias", x => new { x.CursoId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_CursoCategorias_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "Id_categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoCategorias_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id_curso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aulas_CursoId_curso",
                table: "aulas",
                column: "CursoId_curso");

            migrationBuilder.CreateIndex(
                name: "IX_CursoCategorias_CategoriaId",
                table: "CursoCategorias",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_aulas_cursos_CursoId_curso",
                table: "aulas",
                column: "CursoId_curso",
                principalTable: "cursos",
                principalColumn: "Id_curso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aulas_cursos_CursoId_curso",
                table: "aulas");

            migrationBuilder.DropTable(
                name: "CursoCategorias");

            migrationBuilder.DropIndex(
                name: "IX_aulas_CursoId_curso",
                table: "aulas");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "instrutors");

            migrationBuilder.DropColumn(
                name: "CursoId_curso",
                table: "aulas");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "alunos");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "instrutors",
                newName: "Pass");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "alunos",
                newName: "Pass");

            migrationBuilder.AddColumn<int>(
                name: "Id_categoria",
                table: "cursos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id_curso",
                table: "alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cursos_Id_categoria",
                table: "cursos",
                column: "Id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_aulas_Id_curso",
                table: "aulas",
                column: "Id_curso");

            migrationBuilder.AddForeignKey(
                name: "FK_aulas_cursos_Id_curso",
                table: "aulas",
                column: "Id_curso",
                principalTable: "cursos",
                principalColumn: "Id_curso");

            migrationBuilder.AddForeignKey(
                name: "FK_cursos_categorias_Id_categoria",
                table: "cursos",
                column: "Id_categoria",
                principalTable: "categorias",
                principalColumn: "Id_categoria");
        }
    }
}
