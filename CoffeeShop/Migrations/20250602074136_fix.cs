﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeShop.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsTrendingProduct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Name product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", false, "America", 25m },
                    { 2, "Vietnamese product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", false, "Vietnam", 20m },
                    { 3, "UK product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", false, "United Kingdom", 15m },
                    { 4, "India product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", false, "India", 15m },
                    { 5, "Russian product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", false, "Russian", 25m },
                    { 6, "France product", "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp", false, "France", 35m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
