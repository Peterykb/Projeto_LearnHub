using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class ADD_Username_Campo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e63d07d-cd21-4dd9-8378-def5c1c7425d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf48d785-c43c-4ae5-9130-576e6c39b0eb");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "instrutors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "estudante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06b2c16e-37f5-4f4e-a200-e22a95ea0e1a", null, "Instrutor", "INSTRUTOR" },
                    { "0eff01c6-4bc4-4038-8afd-1bc86ede5953", null, "Aluno", "ALUNO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06b2c16e-37f5-4f4e-a200-e22a95ea0e1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eff01c6-4bc4-4038-8afd-1bc86ede5953");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "instrutors");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "estudante");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e63d07d-cd21-4dd9-8378-def5c1c7425d", null, "Instrutor", "INSTRUTOR" },
                    { "bf48d785-c43c-4ae5-9130-576e6c39b0eb", null, "Aluno", "ALUNO" }
                });
        }
    }
}
