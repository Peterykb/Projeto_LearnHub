using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class Migracaotwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carrinhos_alunos_AlunoId",
                table: "carrinhos");

            migrationBuilder.DropForeignKey(
                name: "FK_matriculas_alunos_AlunoId",
                table: "matriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_alunos",
                table: "alunos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07b3f66b-4d0d-4d11-bc37-700dbf2f0eb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29c3215b-2496-4a82-b1c9-8fc4fe3a29e7");

            migrationBuilder.RenameTable(
                name: "alunos",
                newName: "estudante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estudante",
                table: "estudante",
                column: "Id_aluno");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6feafb86-de82-49d0-befa-829aa1d020c4", null, "Aluno", "ALUNO" },
                    { "afa346ee-c530-40e3-9106-576200e0a9a5", null, "Instrutor", "INSTRUTOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_carrinhos_estudante_AlunoId",
                table: "carrinhos",
                column: "AlunoId",
                principalTable: "estudante",
                principalColumn: "Id_aluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_matriculas_estudante_AlunoId",
                table: "matriculas",
                column: "AlunoId",
                principalTable: "estudante",
                principalColumn: "Id_aluno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carrinhos_estudante_AlunoId",
                table: "carrinhos");

            migrationBuilder.DropForeignKey(
                name: "FK_matriculas_estudante_AlunoId",
                table: "matriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estudante",
                table: "estudante");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6feafb86-de82-49d0-befa-829aa1d020c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afa346ee-c530-40e3-9106-576200e0a9a5");

            migrationBuilder.RenameTable(
                name: "estudante",
                newName: "alunos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_alunos",
                table: "alunos",
                column: "Id_aluno");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07b3f66b-4d0d-4d11-bc37-700dbf2f0eb7", null, "Instrutor", "INSTRUTOR" },
                    { "29c3215b-2496-4a82-b1c9-8fc4fe3a29e7", null, "Aluno", "ALUNO" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_carrinhos_alunos_AlunoId",
                table: "carrinhos",
                column: "AlunoId",
                principalTable: "alunos",
                principalColumn: "Id_aluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_matriculas_alunos_AlunoId",
                table: "matriculas",
                column: "AlunoId",
                principalTable: "alunos",
                principalColumn: "Id_aluno");
        }
    }
}
