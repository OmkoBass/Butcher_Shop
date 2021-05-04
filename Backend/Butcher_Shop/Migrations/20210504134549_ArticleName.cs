using Microsoft.EntityFrameworkCore.Migrations;

namespace Butcher_Shop.Migrations
{
    public partial class ArticleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Articles",
                newName: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Butchers_Username",
                table: "Butchers",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Butchers_Username",
                table: "Butchers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Articles",
                newName: "Naziv");
        }
    }
}
