using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class Migracao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06b2c16e-37f5-4f4e-a200-e22a95ea0e1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eff01c6-4bc4-4038-8afd-1bc86ede5953");

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a9b2621-4f46-43e3-937e-eaa2d73a4a62", null, "Aluno", "ALUNO" },
                    { "f545a923-a607-4803-8568-406c3d95b67e", null, "Instrutor", "INSTRUTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a9b2621-4f46-43e3-937e-eaa2d73a4a62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f545a923-a607-4803-8568-406c3d95b67e");

            migrationBuilder.DropColumn(
                name: "descricao",
                table: "cursos");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06b2c16e-37f5-4f4e-a200-e22a95ea0e1a", null, "Instrutor", "INSTRUTOR" },
                    { "0eff01c6-4bc4-4038-8afd-1bc86ede5953", null, "Aluno", "ALUNO" }
                });
        }
    }
}
