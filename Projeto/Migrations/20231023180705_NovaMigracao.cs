using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_cursos_CursosId_curso",
                table: "Aulas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas");

            migrationBuilder.DropIndex(
                name: "IX_Aulas_CursosId_curso",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "CursosId_curso",
                table: "Aulas");

            migrationBuilder.RenameTable(
                name: "Aulas",
                newName: "aulas");

            migrationBuilder.AddColumn<int>(
                name: "Data_criacao",
                table: "cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_aulas",
                table: "aulas",
                column: "Id_aulas");

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    aluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.aluno);
                });

            migrationBuilder.CreateTable(
                name: "AlunoCurso",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoCurso", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunoCurso_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "aluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoCurso_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id_curso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aulas_Id_curso",
                table: "aulas",
                column: "Id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCurso_CursoId",
                table: "AlunoCurso",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_aulas_cursos_Id_curso",
                table: "aulas",
                column: "Id_curso",
                principalTable: "cursos",
                principalColumn: "Id_curso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aulas_cursos_Id_curso",
                table: "aulas");

            migrationBuilder.DropTable(
                name: "AlunoCurso");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_aulas",
                table: "aulas");

            migrationBuilder.DropIndex(
                name: "IX_aulas_Id_curso",
                table: "aulas");

            migrationBuilder.DropColumn(
                name: "Data_criacao",
                table: "cursos");

            migrationBuilder.RenameTable(
                name: "aulas",
                newName: "Aulas");

            migrationBuilder.AddColumn<int>(
                name: "CursosId_curso",
                table: "Aulas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas",
                column: "Id_aulas");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_CursosId_curso",
                table: "Aulas",
                column: "CursosId_curso");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_cursos_CursosId_curso",
                table: "Aulas",
                column: "CursosId_curso",
                principalTable: "cursos",
                principalColumn: "Id_curso");
        }
    }
}
