using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCarrinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_alunos_AlunoId",
                table: "Carrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_cursos_CursoId",
                table: "Carrinho");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho");

            migrationBuilder.DropIndex(
                name: "IX_Carrinho_AlunoId",
                table: "Carrinho");

            migrationBuilder.DropColumn(
                name: "Id_carrinho",
                table: "Carrinho");

            migrationBuilder.RenameTable(
                name: "Carrinho",
                newName: "carrinhos");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "carrinhos",
                newName: "CarrinhoId");

            migrationBuilder.RenameIndex(
                name: "IX_Carrinho_CursoId",
                table: "carrinhos",
                newName: "IX_carrinhos_CursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carrinhos",
                table: "carrinhos",
                columns: new[] { "AlunoId", "CursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_carrinhos_alunos_AlunoId",
                table: "carrinhos",
                column: "AlunoId",
                principalTable: "alunos",
                principalColumn: "Id_aluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carrinhos_cursos_CursoId",
                table: "carrinhos",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carrinhos_alunos_AlunoId",
                table: "carrinhos");

            migrationBuilder.DropForeignKey(
                name: "FK_carrinhos_cursos_CursoId",
                table: "carrinhos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carrinhos",
                table: "carrinhos");

            migrationBuilder.RenameTable(
                name: "carrinhos",
                newName: "Carrinho");

            migrationBuilder.RenameColumn(
                name: "CarrinhoId",
                table: "Carrinho",
                newName: "Quantidade");

            migrationBuilder.RenameIndex(
                name: "IX_carrinhos_CursoId",
                table: "Carrinho",
                newName: "IX_Carrinho_CursoId");

            migrationBuilder.AddColumn<int>(
                name: "Id_carrinho",
                table: "Carrinho",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho",
                column: "Id_carrinho");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_AlunoId",
                table: "Carrinho",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_alunos_AlunoId",
                table: "Carrinho",
                column: "AlunoId",
                principalTable: "alunos",
                principalColumn: "Id_aluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_cursos_CursoId",
                table: "Carrinho",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "Id_curso",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
