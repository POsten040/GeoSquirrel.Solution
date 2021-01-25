using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "svealinneawade@gmail.com", "Svea" },
                    { 2, "nathanschrader@icloud.com", "Nathan" },
                    { 3, "posten.coding@gmail.com", "Patrick" },
                    { 4, "randel.c.moore@gmail.com", "Randel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);
        }
    }
}
