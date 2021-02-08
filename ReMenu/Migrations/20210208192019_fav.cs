using Microsoft.EntityFrameworkCore.Migrations;

namespace ReMenu.Migrations
{
    public partial class fav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a7d69bd-bfbb-40ba-bb99-6d4dd7da3b04");

            migrationBuilder.DropColumn(
                name: "FavoriteRestaurant",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FavoriteMeal",
                table: "Meals");

            migrationBuilder.AddColumn<bool>(
                name: "FavRestaurant",
                table: "Restaurants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FavMeal",
                table: "Meals",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01a47796-49ea-4996-9dc2-852ca5eb1f42", "6bc7acd5-7aa0-4fac-9b6f-782f20b48f8e", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01a47796-49ea-4996-9dc2-852ca5eb1f42");

            migrationBuilder.DropColumn(
                name: "FavRestaurant",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FavMeal",
                table: "Meals");

            migrationBuilder.AddColumn<bool>(
                name: "FavoriteRestaurant",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FavoriteMeal",
                table: "Meals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a7d69bd-bfbb-40ba-bb99-6d4dd7da3b04", "ef5a3d80-a70d-43be-bcb1-52c8642ce7ab", "Foodie", "FOODIE" });
        }
    }
}
