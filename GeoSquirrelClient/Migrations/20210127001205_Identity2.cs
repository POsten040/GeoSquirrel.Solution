using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelClient.Migrations
{
    public partial class Identity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Caches",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Caches",
                columns: new[] { "CacheId", "DateCreated", "Latitude", "Longitude", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.5252m, -122.7163m, "Pittock Mansion", null },
                    { 2, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.5051m, -122.6750m, "Portland", null },
                    { 3, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.88888888m, 13.55888885m, "Location 3", null }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "svealinneawade@gmail.com", "Svea", null },
                    { 2, "nathanschrader@icloud.com", "Nathan", null },
                    { 3, "posten.coding@gmail.com", "Patrick", null },
                    { 4, "randel.c.moore@gmail.com", "Randel", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caches_UserId",
                table: "Caches",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Caches_AspNetUsers_UserId",
                table: "Caches",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caches_AspNetUsers_UserId",
                table: "Caches");

            migrationBuilder.DropIndex(
                name: "IX_Caches_UserId",
                table: "Caches");

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

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Caches");
        }
    }
}
