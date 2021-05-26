using Microsoft.EntityFrameworkCore.Migrations;

namespace Butcher_Shop.Migrations
{
    public partial class ArticlesStorage_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StorageArticles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_Name",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    ButcherStoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_ButcherStores_ButcherStoreId",
                        column: x => x.ButcherStoreId,
                        principalTable: "ButcherStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CustomerId",
                table: "Articles",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_StorageId",
                table: "Articles",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ButcherStoreId",
                table: "Customer",
                column: "ButcherStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Customer_CustomerId",
                table: "Articles",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Storages_StorageId",
                table: "Articles",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Customer_CustomerId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Storages_StorageId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CustomerId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_StorageId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "StorageArticles",
                columns: table => new
                {
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageArticles", x => new { x.StorageId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_StorageArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageArticles_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Name",
                table: "Articles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageArticles_ArticleId",
                table: "StorageArticles",
                column: "ArticleId");
        }
    }
}
