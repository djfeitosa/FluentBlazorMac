using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentBlazorMac.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificacao",
                table: "turma",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NumMaximoAlunos",
                table: "turma",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "aluno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_aluno_TurmaId",
                table: "aluno",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_aluno_turma_TurmaId",
                table: "aluno",
                column: "TurmaId",
                principalTable: "turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aluno_turma_TurmaId",
                table: "aluno");

            migrationBuilder.DropIndex(
                name: "IX_aluno_TurmaId",
                table: "aluno");

            migrationBuilder.DropColumn(
                name: "Identificacao",
                table: "turma");

            migrationBuilder.DropColumn(
                name: "NumMaximoAlunos",
                table: "turma");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "aluno");
        }
    }
}
