using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6feafb86-de82-49d0-befa-829aa1d020c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afa346ee-c530-40e3-9106-576200e0a9a5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e63d07d-cd21-4dd9-8378-def5c1c7425d", null, "Instrutor", "INSTRUTOR" },
                    { "bf48d785-c43c-4ae5-9130-576e6c39b0eb", null, "Aluno", "ALUNO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e63d07d-cd21-4dd9-8378-def5c1c7425d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf48d785-c43c-4ae5-9130-576e6c39b0eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6feafb86-de82-49d0-befa-829aa1d020c4", null, "Aluno", "ALUNO" },
                    { "afa346ee-c530-40e3-9106-576200e0a9a5", null, "Instrutor", "INSTRUTOR" }
                });
        }
    }
}
