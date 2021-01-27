using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelApi.Migrations
{
    public partial class MapUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 1,
                column: "Longitude",
                value: -122.7163m);

            migrationBuilder.UpdateData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 2,
                column: "Longitude",
                value: -122.6750m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 1,
                column: "Longitude",
                value: 122.7163m);

            migrationBuilder.UpdateData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 2,
                column: "Longitude",
                value: 122.6750m);
        }
    }
}
