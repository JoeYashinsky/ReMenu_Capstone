using Microsoft.EntityFrameworkCore.Migrations;

namespace ReMenu.Migrations
{
    public partial class WithAllProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ec7a06-ce7f-4a83-bf0e-dd38b129eb4b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c4d5743-c18d-4c59-a537-c63355ea9981", "4f88eb7f-4d54-47df-a835-8e2e2f85d848", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c4d5743-c18d-4c59-a537-c63355ea9981");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35ec7a06-ce7f-4a83-bf0e-dd38b129eb4b", "63c7b830-6ba2-4a34-9aba-811ede4eb7b3", "Foodie", "FOODIE" });
        }
    }
}
