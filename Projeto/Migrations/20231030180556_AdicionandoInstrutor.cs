using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoInstrutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoCurso_Aluno_AlunoId",
                table: "AlunoCurso");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoCurso_cursos_CursoId",
                table: "AlunoCurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoCurso",
                table: "AlunoCurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno");

            migrationBuilder.RenameTable(
                name: "AlunoCurso",
                newName: "alunoCursos");

            migrationBuilder.RenameTable(
                name: "Aluno",
                newName: "alunos");

            migrationBuilder.RenameIndex(
                name: "IX_AlunoCurso_CursoId",
                table: "alunoCursos",
                newName: "IX_alunoCursos_CursoId");

            migrationBuilder.RenameColumn(
                name: "aluno",
                table: "alunos",
                newName: "Id_aluno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_alunoCursos",
                table: "alunoCursos",
                columns: new[] { "AlunoId", "CursoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_alunos",
                table: "alunos",
                column: "Id_aluno");

            migrationBuilder.CreateTable(
                name: "instrutors",
                columns: table => new
                {
                    Id_Instrutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instrutors", x => x.Id_Instrutor);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_alunoCursos_alunos_AlunoId",
                table: "alunoCursos",
                column: "AlunoId",
                principalTable: "alunos",
                principalColumn: "Id_aluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_alunoCursos_cursos_CursoId",
                table: "alunoCursos",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alunoCursos_alunos_AlunoId",
                table: "alunoCursos");

            migrationBuilder.DropForeignKey(
                name: "FK_alunoCursos_cursos_CursoId",
                table: "alunoCursos");

            migrationBuilder.DropTable(
                name: "instrutors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_alunos",
                table: "alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_alunoCursos",
                table: "alunoCursos");

            migrationBuilder.RenameTable(
                name: "alunos",
                newName: "Aluno");

            migrationBuilder.RenameTable(
                name: "alunoCursos",
                newName: "AlunoCurso");

            migrationBuilder.RenameColumn(
                name: "Id_aluno",
                table: "Aluno",
                newName: "aluno");

            migrationBuilder.RenameIndex(
                name: "IX_alunoCursos_CursoId",
                table: "AlunoCurso",
                newName: "IX_AlunoCurso_CursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno",
                column: "aluno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoCurso",
                table: "AlunoCurso",
                columns: new[] { "AlunoId", "CursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoCurso_Aluno_AlunoId",
                table: "AlunoCurso",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "aluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoCurso_cursos_CursoId",
                table: "AlunoCurso",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
