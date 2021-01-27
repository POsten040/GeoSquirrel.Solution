using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelApi.Migrations
{
    public partial class SomethingFantastic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "CacheGamePlayers",
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
                    table.PrimaryKey("PK_CacheGamePlayers", x => x.CacheGamePlayerId);
                    table.ForeignKey(
                        name: "FK_CacheGamePlayers_Caches_CacheId",
                        column: x => x.CacheId,
                        principalTable: "Caches",
                        principalColumn: "CacheId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CacheGamePlayers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CacheGamePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CacheGamePlayers_CacheId",
                table: "CacheGamePlayers",
                column: "CacheId");

            migrationBuilder.CreateIndex(
                name: "IX_CacheGamePlayers_GameId",
                table: "CacheGamePlayers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CacheGamePlayers_PlayerId",
                table: "CacheGamePlayers",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CacheGamePlayers");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
