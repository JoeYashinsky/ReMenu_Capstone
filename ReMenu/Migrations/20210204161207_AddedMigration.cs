using Microsoft.EntityFrameworkCore.Migrations;

namespace ReMenu.Migrations
{
    public partial class AddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62d900e1-3035-4aa5-a0e3-ad3cc1cb3428");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9f7db9b-a63f-4bef-800b-bf9712b71bae", "2464d208-1ba6-4220-96d8-1fe87b7dc0ce", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9f7db9b-a63f-4bef-800b-bf9712b71bae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62d900e1-3035-4aa5-a0e3-ad3cc1cb3428", "f9b79b3e-73bf-4d2f-815a-45795da8f2b3", "Foodie", "FOODIE" });
        }
    }
}
