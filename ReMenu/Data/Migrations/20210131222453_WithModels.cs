using Microsoft.EntityFrameworkCore.Migrations;

namespace ReMenu.Data.Migrations
{
    public partial class WithModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85bc4069-7bbc-4384-b13d-c6594827ffb6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2903eef4-65c8-4050-9b48-d153f97986a3", "7d4c9ac7-dca8-4fd3-89a7-0dc0cfc64c9d", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2903eef4-65c8-4050-9b48-d153f97986a3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85bc4069-7bbc-4384-b13d-c6594827ffb6", "3441abf5-486a-4b46-abbc-446a00863101", "Foodie", "FOODIE" });
        }
    }
}
