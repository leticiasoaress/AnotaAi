using Microsoft.EntityFrameworkCore.Migrations;

namespace AnotaAi.Repositorio.Migrations
{
    public partial class AdicionarRelacionamentoItemPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemComanda_ComandaId",
                table: "ItemComanda",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemComanda_ProdutoId",
                table: "ItemComanda",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemComanda_Comanda_ComandaId",
                table: "ItemComanda",
                column: "ComandaId",
                principalTable: "Comanda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemComanda_Produto_ProdutoId",
                table: "ItemComanda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemComanda_Comanda_ComandaId",
                table: "ItemComanda");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemComanda_Produto_ProdutoId",
                table: "ItemComanda");

            migrationBuilder.DropIndex(
                name: "IX_ItemComanda_ComandaId",
                table: "ItemComanda");

            migrationBuilder.DropIndex(
                name: "IX_ItemComanda_ProdutoId",
                table: "ItemComanda");
        }
    }
}
