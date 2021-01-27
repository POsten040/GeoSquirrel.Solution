using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelApi.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 45.5252m, 122.7163m, "Pittock Mansion" });

            migrationBuilder.UpdateData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 45.5051m, 122.6750m, "Portland" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 17.88888888m, 7.58888855m, "Location 1" });

            migrationBuilder.UpdateData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 20.88888888m, 10.58888855m, "Location 2" });
        }
    }
}
