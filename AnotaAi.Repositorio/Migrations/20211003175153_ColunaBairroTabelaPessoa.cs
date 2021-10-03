using Microsoft.EntityFrameworkCore.Migrations;

namespace AnotaAi.Repositorio.Migrations
{
    public partial class ColunaBairroTabelaPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Pessoa",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Pessoa");
        }
    }
}
