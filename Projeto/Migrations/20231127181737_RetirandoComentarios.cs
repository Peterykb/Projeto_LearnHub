using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class RetirandoComentarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id_comentarios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_public = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id_comentarios);
                    table.ForeignKey(
                        name: "FK_Comentarios_alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "alunos",
                        principalColumn: "Id_aluno");
                    table.ForeignKey(
                        name: "FK_Comentarios_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id_curso");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_AlunoId",
                table: "Comentarios",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_CursoId",
                table: "Comentarios",
                column: "CursoId");
        }
    }
}
