using Microsoft.EntityFrameworkCore.Migrations;

namespace ReMenu.Migrations
{
    public partial class NewMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fadd69c-fa30-4c0a-9c35-830f4312f962");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f72becca-9086-49fc-9fe1-5a3c168d26c9", "81d17c4b-726d-4952-a92d-85a31613a0bc", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f72becca-9086-49fc-9fe1-5a3c168d26c9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fadd69c-fa30-4c0a-9c35-830f4312f962", "e4dd6647-d58e-48a7-ad17-af1d0a06bc11", "Foodie", "FOODIE" });
        }
    }
}
