using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessLogic.Migrations
{
    public partial class ultimatumm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyProducts_Products_ProductId",
                table: "BuyProducts");

            migrationBuilder.DropIndex(
                name: "IX_BuyProducts_ProductId",
                table: "BuyProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "BuyProducts");

            migrationBuilder.CreateIndex(
                name: "IX_BuyProducts_IdProduct",
                table: "BuyProducts",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyProducts_Products_IdProduct",
                table: "BuyProducts",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyProducts_Products_IdProduct",
                table: "BuyProducts");

            migrationBuilder.DropIndex(
                name: "IX_BuyProducts_IdProduct",
                table: "BuyProducts");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "BuyProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuyProducts_ProductId",
                table: "BuyProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyProducts_Products_ProductId",
                table: "BuyProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
