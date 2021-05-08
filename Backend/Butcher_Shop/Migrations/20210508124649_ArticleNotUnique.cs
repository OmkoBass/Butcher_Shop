using Microsoft.EntityFrameworkCore.Migrations;

namespace Butcher_Shop.Migrations
{
    public partial class ArticleNotUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_ButcherStoreId",
                table: "Employees",
                column: "ButcherStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ButcherStores_ButcherStoreId",
                table: "Employees",
                column: "ButcherStoreId",
                principalTable: "ButcherStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ButcherStores_ButcherStoreId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ButcherStoreId",
                table: "Employees");
        }
    }
}
