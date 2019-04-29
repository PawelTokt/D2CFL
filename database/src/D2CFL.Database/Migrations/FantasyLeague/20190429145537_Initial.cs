using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace D2CFL.Database.Migrations.FantasyLeague
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fantasyleague");

            migrationBuilder.CreateTable(
                name: "Organization",
                schema: "fantasyleague",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "fantasyleague",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    KillCoefficient = table.Column<int>(nullable: false),
                    AssistCoefficient = table.Column<int>(nullable: false),
                    DeathCoefficient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                schema: "fantasyleague",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                schema: "fantasyleague",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    OrganizationId = table.Column<Guid>(nullable: true),
                    PositionId = table.Column<Guid>(nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "fantasyleague",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Player_Position_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "fantasyleague",
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                schema: "fantasyleague",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    TournamentId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "fantasyleague",
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatistics",
                schema: "fantasyleague",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    PlayerId = table.Column<Guid>(nullable: false),
                    MatchesPlayed = table.Column<int>(nullable: false),
                    TotalKills = table.Column<int>(nullable: false),
                    TotalAssists = table.Column<int>(nullable: false),
                    TotalDeaths = table.Column<int>(nullable: false),
                    TotalPoints = table.Column<int>(nullable: false),
                    AverageKills = table.Column<double>(nullable: false),
                    AverageAssists = table.Column<double>(nullable: false),
                    AverageDeaths = table.Column<double>(nullable: false),
                    AveragePoints = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "fantasyleague",
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                schema: "fantasyleague",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    OrganizationId = table.Column<Guid>(nullable: true),
                    MatchId = table.Column<Guid>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Match_MatchId",
                        column: x => x.MatchId,
                        principalSchema: "fantasyleague",
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "fantasyleague",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_TournamentId",
                schema: "fantasyleague",
                table: "Match",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_MatchId",
                schema: "fantasyleague",
                table: "Participant",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_OrganizationId",
                schema: "fantasyleague",
                table: "Participant",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_OrganizationId",
                schema: "fantasyleague",
                table: "Player",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_PositionId",
                schema: "fantasyleague",
                table: "Player",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_PlayerId",
                schema: "fantasyleague",
                table: "PlayerStatistics",
                column: "PlayerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participant",
                schema: "fantasyleague");

            migrationBuilder.DropTable(
                name: "PlayerStatistics",
                schema: "fantasyleague");

            migrationBuilder.DropTable(
                name: "Match",
                schema: "fantasyleague");

            migrationBuilder.DropTable(
                name: "Player",
                schema: "fantasyleague");

            migrationBuilder.DropTable(
                name: "Tournament",
                schema: "fantasyleague");

            migrationBuilder.DropTable(
                name: "Organization",
                schema: "fantasyleague");

            migrationBuilder.DropTable(
                name: "Position",
                schema: "fantasyleague");
        }
    }
}
