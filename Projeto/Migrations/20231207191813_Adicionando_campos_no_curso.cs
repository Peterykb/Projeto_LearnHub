using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_campos_no_curso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Idiomas",
                table: "cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idiomas",
                table: "cursos");
        }
    }
}
