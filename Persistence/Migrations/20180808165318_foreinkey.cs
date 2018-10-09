using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessLogic.Migrations
{
    public partial class foreinkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Clients_ClientsId",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Users_UsersId",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ProvidersId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProvidersId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProvidersId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Buys",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "ClientsId",
                table: "Buys",
                newName: "IdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_UsersId",
                table: "Buys",
                newName: "IX_Buys_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_ClientsId",
                table: "Buys",
                newName: "IX_Buys_IdClient");

            migrationBuilder.AddColumn<int>(
                name: "IdProvider",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProvider",
                table: "Products",
                column: "IdProvider");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Clients_IdClient",
                table: "Buys",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Users_IdUser",
                table: "Buys",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_IdProvider",
                table: "Products",
                column: "IdProvider",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Clients_IdClient",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Users_IdUser",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_IdProvider",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdProvider",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdProvider",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Buys",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Buys",
                newName: "ClientsId");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_IdUser",
                table: "Buys",
                newName: "IX_Buys_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_IdClient",
                table: "Buys",
                newName: "IX_Buys_ClientsId");

            migrationBuilder.AddColumn<int>(
                name: "ProvidersId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProvidersId",
                table: "Products",
                column: "ProvidersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Clients_ClientsId",
                table: "Buys",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Users_UsersId",
                table: "Buys",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_ProvidersId",
                table: "Products",
                column: "ProvidersId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
