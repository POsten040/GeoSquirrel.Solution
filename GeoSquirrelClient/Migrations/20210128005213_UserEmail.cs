using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelClient.Migrations
{
    public partial class UserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caches_AspNetUsers_UserId",
                table: "Caches");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_UserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Caches_UserId",
                table: "Caches");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Players",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Caches",
                newName: "UserEmail");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Caches",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Players",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Caches",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Caches",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
