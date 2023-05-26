using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebStore.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fdb3756-dee1-42b2-87b2-7f23883252c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c8a5c96-ee39-4ebf-84d8-e797b816c669");

            migrationBuilder.AddColumn<string>(
                name: "CollectionStatus",
                table: "ProductEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a57b8e1-0534-4eb6-a7a9-d7446141e02f", null, "user", null },
                    { "da83f837-267f-493a-be85-074efc69360b", null, "admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a57b8e1-0534-4eb6-a7a9-d7446141e02f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da83f837-267f-493a-be85-074efc69360b");

            migrationBuilder.DropColumn(
                name: "CollectionStatus",
                table: "ProductEntity");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fdb3756-dee1-42b2-87b2-7f23883252c6", null, "admin", null },
                    { "6c8a5c96-ee39-4ebf-84d8-e797b816c669", null, "user", null }
                });
        }
    }
}
