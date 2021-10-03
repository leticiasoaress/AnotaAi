using Microsoft.EntityFrameworkCore.Migrations;

namespace AnotaAi.Repositorio.Migrations
{
    public partial class RetirarCampoAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Cargo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Funcionario",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Categoria",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Cargo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
