using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class Modelando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aulas_modulos_Moduloid",
                table: "aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_alunos_AlunoId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_cursos_CursoId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoCategorias_categorias_CategoriaId",
                table: "CursoCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoCategorias_cursos_CursoId",
                table: "CursoCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_cursos_instrutors_InstrutorId",
                table: "cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_matriculas_alunos_AlunoId",
                table: "matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_matriculas_cursos_CursoId",
                table: "matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_modulos_cursos_CursoId",
                table: "modulos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CursoCategorias");

            migrationBuilder.AddForeignKey(
                name: "FK_aulas_modulos_Moduloid",
                table: "aulas",
                column: "Moduloid",
                principalTable: "modulos",
                principalColumn: "Id_Modulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_alunos_AlunoId",
                table: "Comentarios",
                column: "AlunoId",
                principalTable: "alunos",
                principalColumn: "Id_aluno");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_cursos_CursoId",
                table: "Comentarios",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoCategorias_categorias_CategoriaId",
                table: "CursoCategorias",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id_categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoCategorias_cursos_CursoId",
                table: "CursoCategorias",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso");

            migrationBuilder.AddForeignKey(
                name: "FK_cursos_instrutors_InstrutorId",
                table: "cursos",
                column: "InstrutorId",
                principalTable: "instrutors",
                principalColumn: "Id_Instrutor");

            migrationBuilder.AddForeignKey(
                name: "FK_matriculas_alunos_AlunoId",
                table: "matriculas",
                column: "AlunoId",
                principalTable: "alunos",
                principalColumn: "Id_aluno");

            migrationBuilder.AddForeignKey(
                name: "FK_matriculas_cursos_CursoId",
                table: "matriculas",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso");

            migrationBuilder.AddForeignKey(
                name: "FK_modulos_cursos_CursoId",
                table: "modulos",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aulas_modulos_Moduloid",
                table: "aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_alunos_AlunoId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_cursos_CursoId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoCategorias_categorias_CategoriaId",
                table: "CursoCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoCategorias_cursos_CursoId",
                table: "CursoCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_cursos_instrutors_InstrutorId",
                table: "cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_matriculas_alunos_AlunoId",
                table: "matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_matriculas_cursos_CursoId",
                table: "matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_modulos_cursos_CursoId",
                table: "modulos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CursoCategorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_aulas_modulos_Moduloid",
                table: "aulas",
                column: "Moduloid",
                principalTable: "modulos",
                principalColumn: "Id_Modulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_alunos_AlunoId",
                table: "Comentarios",
                column: "AlunoId",
                principalTable: "alunos",
                principalColumn: "Id_aluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_cursos_CursoId",
                table: "Comentarios",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoCategorias_categorias_CategoriaId",
                table: "CursoCategorias",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id_categoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoCategorias_cursos_CursoId",
                table: "CursoCategorias",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cursos_instrutors_InstrutorId",
                table: "cursos",
                column: "InstrutorId",
                principalTable: "instrutors",
                principalColumn: "Id_Instrutor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_matriculas_alunos_AlunoId",
                table: "matriculas",
                column: "AlunoId",
                principalTable: "alunos",
                principalColumn: "Id_aluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_matriculas_cursos_CursoId",
                table: "matriculas",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modulos_cursos_CursoId",
                table: "modulos",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
