using Microsoft.EntityFrameworkCore.Migrations;

namespace Butcher_Shop.Migrations
{
    public partial class ButcherStoreHasStorages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Customer_CustomerId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_ButcherStores_ButcherStoreId",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ButcherStoreId",
                table: "Customers",
                newName: "IX_Customers_ButcherStoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Customers_CustomerId",
                table: "Articles",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ButcherStores_ButcherStoreId",
                table: "Customers",
                column: "ButcherStoreId",
                principalTable: "ButcherStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Customers_CustomerId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ButcherStores_ButcherStoreId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ButcherStoreId",
                table: "Customer",
                newName: "IX_Customer_ButcherStoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Customer_CustomerId",
                table: "Articles",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_ButcherStores_ButcherStoreId",
                table: "Customer",
                column: "ButcherStoreId",
                principalTable: "ButcherStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
