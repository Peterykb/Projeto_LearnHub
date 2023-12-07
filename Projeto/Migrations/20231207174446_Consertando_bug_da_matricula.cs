using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class Consertando_bug_da_matricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Data_update",
                table: "cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_update",
                table: "cursos");
        }
    }
}
