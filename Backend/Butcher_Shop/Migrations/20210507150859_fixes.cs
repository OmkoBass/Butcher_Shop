using Microsoft.EntityFrameworkCore.Migrations;

namespace Butcher_Shop.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ButcherStores_ButcherStoreId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ButcherStoreId",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Butchers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Butchers",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

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
    }
}
