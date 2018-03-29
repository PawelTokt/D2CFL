using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace D2CFL.Migrations.Migrations.League
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "league");

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "league",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssistCoefficient = table.Column<double>(nullable: false),
                    DeathCoefficient = table.Column<double>(nullable: false),
                    KillCoefficient = table.Column<double>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "league",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Region = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "league",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(maxLength: 50, nullable: false),
                    PositionEntityId = table.Column<int>(nullable: true),
                    TeamEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Positions_PositionEntityId",
                        column: x => x.PositionEntityId,
                        principalSchema: "league",
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamEntityId",
                        column: x => x.TeamEntityId,
                        principalSchema: "league",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionEntityId",
                schema: "league",
                table: "Players",
                column: "PositionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamEntityId",
                schema: "league",
                table: "Players",
                column: "TeamEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players",
                schema: "league");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "league");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "league");
        }
    }
}