using Microsoft.EntityFrameworkCore.Migrations;

namespace ReMenu.Migrations
{
    public partial class WithFavs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd78a042-9d3d-4503-bd42-355be499337c");

            migrationBuilder.AddColumn<bool>(
                name: "FavoriteRestaurant",
                table: "Restaurants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FavoriteMeal",
                table: "Meals",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35ec7a06-ce7f-4a83-bf0e-dd38b129eb4b", "63c7b830-6ba2-4a34-9aba-811ede4eb7b3", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ec7a06-ce7f-4a83-bf0e-dd38b129eb4b");

            migrationBuilder.DropColumn(
                name: "FavoriteRestaurant",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FavoriteMeal",
                table: "Meals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd78a042-9d3d-4503-bd42-355be499337c", "aedd6cbd-5ed6-479c-a17b-91d951a870bd", "Foodie", "FOODIE" });
        }
    }
}
