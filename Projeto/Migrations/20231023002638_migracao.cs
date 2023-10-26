using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class migracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "cursos",
                columns: table => new
                {
                    Id_curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Aulas",
                columns: table => new
                {
                    Id_aulas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_curso = table.Column<int>(type: "int", nullable: false),
                    CursosId_curso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id_aulas);
                    table.ForeignKey(
                        name: "FK_Aulas_cursos_CursosId_curso",
                        column: x => x.CursosId_curso,
                        principalTable: "cursos",
                        principalColumn: "Id_curso");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_CursosId_curso",
                table: "Aulas",
                column: "CursosId_curso");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_CategoriasId_categoria",
                table: "cursos",
                column: "CategoriasId_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_Id_categoria",
                table: "cursos",
                column: "Id_categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
