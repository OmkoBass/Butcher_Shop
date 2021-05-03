using Microsoft.EntityFrameworkCore.Migrations;

namespace Butcher_Shop.Migrations
{
    public partial class RequiredButcherStoreForStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storage_ButcherStores_ButcherStoreId",
                table: "Storage");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageArticle_Article_ArticleId",
                table: "StorageArticle");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageArticle_Storage_StorageId",
                table: "StorageArticle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StorageArticle",
                table: "StorageArticle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storage",
                table: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.RenameTable(
                name: "StorageArticle",
                newName: "StorageArticles");

            migrationBuilder.RenameTable(
                name: "Storage",
                newName: "Storages");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_StorageArticle_ArticleId",
                table: "StorageArticles",
                newName: "IX_StorageArticles_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Storage_ButcherStoreId",
                table: "Storages",
                newName: "IX_Storages_ButcherStoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StorageArticles",
                table: "StorageArticles",
                columns: new[] { "StorageId", "ArticleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storages",
                table: "Storages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageArticles_Articles_ArticleId",
                table: "StorageArticles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageArticles_Storages_StorageId",
                table: "StorageArticles",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_ButcherStores_ButcherStoreId",
                table: "Storages",
                column: "ButcherStoreId",
                principalTable: "ButcherStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageArticles_Articles_ArticleId",
                table: "StorageArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageArticles_Storages_StorageId",
                table: "StorageArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_ButcherStores_ButcherStoreId",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storages",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StorageArticles",
                table: "StorageArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Storages",
                newName: "Storage");

            migrationBuilder.RenameTable(
                name: "StorageArticles",
                newName: "StorageArticle");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Article");

            migrationBuilder.RenameIndex(
                name: "IX_Storages_ButcherStoreId",
                table: "Storage",
                newName: "IX_Storage_ButcherStoreId");

            migrationBuilder.RenameIndex(
                name: "IX_StorageArticles_ArticleId",
                table: "StorageArticle",
                newName: "IX_StorageArticle_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storage",
                table: "Storage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StorageArticle",
                table: "StorageArticle",
                columns: new[] { "StorageId", "ArticleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_ButcherStores_ButcherStoreId",
                table: "Storage",
                column: "ButcherStoreId",
                principalTable: "ButcherStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageArticle_Article_ArticleId",
                table: "StorageArticle",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageArticle_Storage_StorageId",
                table: "StorageArticle",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
