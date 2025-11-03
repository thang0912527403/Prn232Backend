using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Prn232Project.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Fashion" },
                    { 3, "Home & Garden" },
                    { 4, "Toys & Hobbies" },
                    { 5, "Automotive" },
                    { 6, "Health & Beauty" },
                    { 7, "Sports" },
                    { 8, "Books & Media" },
                    { 9, "Art & Collectibles" },
                    { 10, "Pet Supplies" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "avatarURL", "email", "password", "role", "username" },
                values: new object[,]
                {
                    { 1, "https://example.com/avatars/seller1.jpg", "seller1@example.com", "123456", "seller", "seller1" },
                    { 2, "https://example.com/avatars/seller2.jpg", "seller2@example.com", "123456", "seller", "seller2" },
                    { 3, "https://example.com/avatars/seller3.jpg", "seller3@example.com", "123456", "seller", "seller3" },
                    { 4, "https://example.com/avatars/buyer1.jpg", "buyer1@example.com", "123456", "buyer", "buyer1" },
                    { 5, "https://example.com/avatars/buyer2.jpg", "buyer2@example.com", "123456", "buyer", "buyer2" },
                    { 6, "https://example.com/avatars/buyer3.jpg", "buyer3@example.com", "123456", "buyer", "buyer3" },
                    { 7, "https://example.com/avatars/buyer4.jpg", "buyer4@example.com", "123456", "buyer", "buyer4" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "auctionEndTime", "categoryId", "description", "images", "isAuction", "price", "sellerId", "title" },
                values: new object[,]
                {
                    { 1, null, 1, "Brand new, unopened box. Official Apple warranty.", "https://example.com/images/iphone15.jpg", false, 34990000m, 1, "iPhone 15 Pro Max 256GB" },
                    { 2, null, 1, "Flagship Android phone, 12GB RAM, 512GB storage.", "https://example.com/images/s24ultra.jpg", false, 28990000m, 1, "Samsung Galaxy S24 Ultra" },
                    { 3, null, 2, "Classic white sneakers, size 42.", "https://example.com/images/airforce1.jpg", false, 2500000m, 1, "Nike Air Force 1" },
                    { 4, null, 3, "Solid oak coffee table, modern style.", "https://example.com/images/coffeetable.jpg", false, 1800000m, 1, "Wooden Coffee Table" },
                    { 5, null, 4, "Brand new, collector’s edition set.", "https://example.com/images/lego-falcon.jpg", false, 5500000m, 1, "Lego Star Wars Millennium Falcon" },
                    { 6, null, 5, "High-performance synthetic motor oil.", "https://example.com/images/mobil1.jpg", false, 900000m, 1, "Mobil 1 Engine Oil 5W-30" },
                    { 7, null, 6, "Anti-aging moisturizer for daily use.", "https://example.com/images/loreal.jpg", false, 450000m, 1, "L’Oreal Face Cream" },
                    { 8, null, 7, "Official size 5 match ball.", "https://example.com/images/adidasball.jpg", false, 700000m, 1, "Adidas Football" },
                    { 9, null, 8, "All 7 books in a hardcover collection.", "https://example.com/images/harrypotter.jpg", false, 950000m, 1, "Harry Potter Box Set" },
                    { 10, new DateTime(2025, 11, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 9, "Original 1960s oil painting, framed.", "https://example.com/images/painting.jpg", true, 8500000m, 1, "Vintage Painting" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
