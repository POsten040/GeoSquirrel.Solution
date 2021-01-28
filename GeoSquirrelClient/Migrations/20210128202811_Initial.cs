using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSquirrelClient.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caches",
                columns: table => new
                {
                    CacheId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caches", x => x.CacheId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CacheGame",
                columns: table => new
                {
                    CacheGameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(nullable: false),
                    CacheId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CacheGame", x => x.CacheGameId);
                    table.ForeignKey(
                        name: "FK_CacheGame_Caches_CacheId",
                        column: x => x.CacheId,
                        principalTable: "Caches",
                        principalColumn: "CacheId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CacheGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayer",
                columns: table => new
                {
                    GamePlayerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayer", x => x.GamePlayerId);
                    table.ForeignKey(
                        name: "FK_GamePlayer_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayer_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CacheGamePlayers",
                columns: table => new
                {
                    CacheGamePlayerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CacheGameId = table.Column<int>(nullable: false),
                    GamePlayerId = table.Column<int>(nullable: false),
                    FoundCache = table.Column<bool>(nullable: false),
                    CacheId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CacheGamePlayers", x => x.CacheGamePlayerId);
                    table.ForeignKey(
                        name: "FK_CacheGamePlayers_CacheGame_CacheGameId",
                        column: x => x.CacheGameId,
                        principalTable: "CacheGame",
                        principalColumn: "CacheGameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CacheGamePlayers_Caches_CacheId",
                        column: x => x.CacheId,
                        principalTable: "Caches",
                        principalColumn: "CacheId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CacheGamePlayers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CacheGamePlayers_GamePlayer_GamePlayerId",
                        column: x => x.GamePlayerId,
                        principalTable: "GamePlayer",
                        principalColumn: "GamePlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Caches",
                columns: new[] { "CacheId", "DateCreated", "Latitude", "Longitude", "Name", "UserEmail" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.5252m, -122.7163m, "Pittock Mansion", null },
                    { 13, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.644800m, -77.216721m, "New Dehli", null },
                    { 12, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.651070m, -73.561668m, "Toronto", null },
                    { 11, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.3949m, 84.1240m, "Nepal", null },
                    { 9, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.185884m, 79.974380m, "Jabalpur", null },
                    { 8, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.572645m, 88.363892m, "kolkataindia", null },
                    { 10, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0820m, 8.6753m, "Nigeria", null },
                    { 6, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.751244m, 37.618423m, "Russia", null },
                    { 5, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.367474m, -82.996216m, "Ohio", null },
                    { 4, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.798363m, -156.331924m, "Maui", null },
                    { 3, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.350140m, -6.266155m, "Ireland", null },
                    { 2, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.5051m, -122.6750m, "Portland", null },
                    { 7, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.508888m, -73.561668m, "Montreal", null }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name", "UserEmail" },
                values: new object[,]
                {
                    { 1, "Game 1", null },
                    { 2, "Game 2", null }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Name", "UserEmail" },
                values: new object[,]
                {
                    { 3, "Patrick", "posten.coding@gmail.com" },
                    { 1, "Svea", "svealinneawade@gmail.com" },
                    { 2, "Nathan", "nathanschrader@icloud.com" },
                    { 4, "Randel", "randel.c.moore@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CacheGame_CacheId",
                table: "CacheGame",
                column: "CacheId");

            migrationBuilder.CreateIndex(
                name: "IX_CacheGame_GameId",
                table: "CacheGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CacheGamePlayers_CacheGameId",
                table: "CacheGamePlayers",
                column: "CacheGameId");

            migrationBuilder.CreateIndex(
                name: "IX_CacheGamePlayers_CacheId",
                table: "CacheGamePlayers",
                column: "CacheId");

            migrationBuilder.CreateIndex(
                name: "IX_CacheGamePlayers_GameId",
                table: "CacheGamePlayers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CacheGamePlayers_GamePlayerId",
                table: "CacheGamePlayers",
                column: "GamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_GameId",
                table: "GamePlayer",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_PlayerId",
                table: "GamePlayer",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CacheGamePlayers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CacheGame");

            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.DropTable(
                name: "Caches");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
