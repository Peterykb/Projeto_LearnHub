using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class Migracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alunos",
                columns: table => new
                {
                    Id_aluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunos", x => x.Id_aluno);
                });

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "instrutors",
                columns: table => new
                {
                    Id_Instrutor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instrutors", x => x.Id_Instrutor);
                });

            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    Id_curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_criacao = table.Column<int>(type: "int", nullable: false),
                    Id_categoria = table.Column<int>(type: "int", nullable: true),
                    CategoriasId_categoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.Id_curso);
                    table.ForeignKey(
                        name: "FK_cursos_categorias_CategoriasId_categoria",
                        column: x => x.CategoriasId_categoria,
                        principalTable: "categorias",
                        principalColumn: "Id_categoria");
                    table.ForeignKey(
                        name: "FK_cursos_categorias_Id_categoria",
                        column: x => x.Id_categoria,
                        principalTable: "categorias",
                        principalColumn: "Id_categoria");
                });

            migrationBuilder.CreateTable(
                name: "aulas",
                columns: table => new
                {
                    Id_aulas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aulas", x => x.Id_aulas);
                    table.ForeignKey(
                        name: "FK_aulas_cursos_Id_curso",
                        column: x => x.Id_curso,
                        principalTable: "cursos",
                        principalColumn: "Id_curso");
                });

            migrationBuilder.CreateTable(
                name: "matriculas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriculas", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_matriculas_alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "alunos",
                        principalColumn: "Id_aluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_matriculas_cursos_CursoId",
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
                name: "IX_cursos_CategoriasId_categoria",
                table: "cursos",
                column: "CategoriasId_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_Id_categoria",
                table: "cursos",
                column: "Id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_CursoId",
                table: "matriculas",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aulas");

            migrationBuilder.DropTable(
                name: "instrutors");

            migrationBuilder.DropTable(
                name: "matriculas");

            migrationBuilder.DropTable(
                name: "alunos");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
