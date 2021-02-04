using Microsoft.EntityFrameworkCore.Migrations;

namespace ReMenu.Migrations
{
    public partial class newestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6852ced8-a44c-4c0e-884c-6954e0cc165c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62d900e1-3035-4aa5-a0e3-ad3cc1cb3428", "f9b79b3e-73bf-4d2f-815a-45795da8f2b3", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62d900e1-3035-4aa5-a0e3-ad3cc1cb3428");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6852ced8-a44c-4c0e-884c-6954e0cc165c", "4e591e59-5f28-4a8a-a338-1d11eeeec2d3", "Foodie", "FOODIE" });
        }
    }
}
