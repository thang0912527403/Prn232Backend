using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prn232Project.Migrations
{
    /// <inheritdoc />
    public partial class editseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "123456");
        }
    }
}
