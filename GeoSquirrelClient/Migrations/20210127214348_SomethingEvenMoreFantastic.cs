using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelClient.Migrations
{
    public partial class SomethingEvenMoreFantastic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CachePlayers_Caches_CacheId",
                table: "CachePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_CachePlayers_Games_GameId",
                table: "CachePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_CachePlayers_Players_PlayerId",
                table: "CachePlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CachePlayers",
                table: "CachePlayers");

            migrationBuilder.RenameTable(
                name: "CachePlayers",
                newName: "CacheGamePlayers");

            migrationBuilder.RenameIndex(
                name: "IX_CachePlayers_PlayerId",
                table: "CacheGamePlayers",
                newName: "IX_CacheGamePlayers_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_CachePlayers_GameId",
                table: "CacheGamePlayers",
                newName: "IX_CacheGamePlayers_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_CachePlayers_CacheId",
                table: "CacheGamePlayers",
                newName: "IX_CacheGamePlayers_CacheId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CacheGamePlayers",
                table: "CacheGamePlayers",
                column: "CacheGamePlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CacheGamePlayers_Caches_CacheId",
                table: "CacheGamePlayers",
                column: "CacheId",
                principalTable: "Caches",
                principalColumn: "CacheId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CacheGamePlayers_Games_GameId",
                table: "CacheGamePlayers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CacheGamePlayers_Players_PlayerId",
                table: "CacheGamePlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CacheGamePlayers_Caches_CacheId",
                table: "CacheGamePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_CacheGamePlayers_Games_GameId",
                table: "CacheGamePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_CacheGamePlayers_Players_PlayerId",
                table: "CacheGamePlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CacheGamePlayers",
                table: "CacheGamePlayers");

            migrationBuilder.RenameTable(
                name: "CacheGamePlayers",
                newName: "CachePlayers");

            migrationBuilder.RenameIndex(
                name: "IX_CacheGamePlayers_PlayerId",
                table: "CachePlayers",
                newName: "IX_CachePlayers_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_CacheGamePlayers_GameId",
                table: "CachePlayers",
                newName: "IX_CachePlayers_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_CacheGamePlayers_CacheId",
                table: "CachePlayers",
                newName: "IX_CachePlayers_CacheId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CachePlayers",
                table: "CachePlayers",
                column: "CacheGamePlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CachePlayers_Caches_CacheId",
                table: "CachePlayers",
                column: "CacheId",
                principalTable: "Caches",
                principalColumn: "CacheId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CachePlayers_Games_GameId",
                table: "CachePlayers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CachePlayers_Players_PlayerId",
                table: "CachePlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
