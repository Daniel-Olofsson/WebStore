using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebStore.Migrations
{
    /// <inheritdoc />
    public partial class AddViewmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0630721f-fb75-4c05-94f2-8b910f6da4e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a026e7ed-36cb-4d7f-94ff-cecfbdc17569");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fdb3756-dee1-42b2-87b2-7f23883252c6", null, "admin", null },
                    { "6c8a5c96-ee39-4ebf-84d8-e797b816c669", null, "user", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fdb3756-dee1-42b2-87b2-7f23883252c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c8a5c96-ee39-4ebf-84d8-e797b816c669");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0630721f-fb75-4c05-94f2-8b910f6da4e1", null, "user", null },
                    { "a026e7ed-36cb-4d7f-94ff-cecfbdc17569", null, "admin", null }
                });
        }
    }
}
