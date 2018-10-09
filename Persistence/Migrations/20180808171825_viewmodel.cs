using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessLogic.Migrations
{
    public partial class viewmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Buys_BuyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BuyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BuyId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "BuyProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: true),
                    IdBuy = table.Column<int>(nullable: false),
                    Quatity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyProducts_Buys_IdBuy",
                        column: x => x.IdBuy,
                        principalTable: "Buys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyProducts_IdBuy",
                table: "BuyProducts",
                column: "IdBuy");

            migrationBuilder.CreateIndex(
                name: "IX_BuyProducts_ProductId",
                table: "BuyProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyProducts");

            migrationBuilder.AddColumn<int>(
                name: "BuyId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyId",
                table: "Products",
                column: "BuyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Buys_BuyId",
                table: "Products",
                column: "BuyId",
                principalTable: "Buys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
