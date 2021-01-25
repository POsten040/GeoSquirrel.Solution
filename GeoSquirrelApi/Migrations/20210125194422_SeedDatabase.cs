using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelApi.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Caches",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Caches",
                columns: new[] { "CacheId", "DateCreated", "Latitude", "Longitude", "Name" },
                values: new object[] { 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17.88888888m, 7.58888855m, "Location 1" });

            migrationBuilder.InsertData(
                table: "Caches",
                columns: new[] { "CacheId", "DateCreated", "Latitude", "Longitude", "Name" },
                values: new object[] { 2, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.88888888m, 10.58888855m, "Location 2" });

            migrationBuilder.InsertData(
                table: "Caches",
                columns: new[] { "CacheId", "DateCreated", "Latitude", "Longitude", "Name" },
                values: new object[] { 3, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.88888888m, 13.55888885m, "Location 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Caches",
                keyColumn: "CacheId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "DateCreated",
                table: "Caches",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
