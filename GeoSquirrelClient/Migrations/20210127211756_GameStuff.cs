using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelClient.Migrations
{
    public partial class GameStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerCaches");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "CachePlayers",
                columns: table => new
                {
                    CacheGamePlayerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: false),
                    CacheId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    FoundCache = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CachePlayers", x => x.CacheGamePlayerId);
                    table.ForeignKey(
                        name: "FK_CachePlayers_Caches_CacheId",
                        column: x => x.CacheId,
                        principalTable: "Caches",
                        principalColumn: "CacheId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CachePlayers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CachePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name" },
                values: new object[] { 1, "Game 1" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name" },
                values: new object[] { 2, "Game 2" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CachePlayers_CacheId",
                table: "CachePlayers",
                column: "CacheId");

            migrationBuilder.CreateIndex(
                name: "IX_CachePlayers_GameId",
                table: "CachePlayers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CachePlayers_PlayerId",
                table: "CachePlayers",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "CachePlayers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Players_UserId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "PlayerCaches",
                columns: table => new
                {
                    PlayerCacheId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CacheId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCaches", x => x.PlayerCacheId);
                    table.ForeignKey(
                        name: "FK_PlayerCaches_Caches_CacheId",
                        column: x => x.CacheId,
                        principalTable: "Caches",
                        principalColumn: "CacheId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCaches_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCaches_CacheId",
                table: "PlayerCaches",
                column: "CacheId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCaches_PlayerId",
                table: "PlayerCaches",
                column: "PlayerId");
        }
    }
}
