using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace example.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTabaleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_ShoppingCarts_ShoppingCartId",
                table: "ProductReviews");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ProductReviews",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductReviews_ShoppingCartId",
                table: "ProductReviews",
                newName: "IX_ProductReviews_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ProductReviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ApplicationUserId",
                table: "ProductReviews",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_AspNetUsers_ApplicationUserId",
                table: "ProductReviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Products_ProductId",
                table: "ProductReviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_AspNetUsers_ApplicationUserId",
                table: "ProductReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Products_ProductId",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_ApplicationUserId",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ProductReviews");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductReviews",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                newName: "IX_ProductReviews_ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_ShoppingCarts_ShoppingCartId",
                table: "ProductReviews",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
