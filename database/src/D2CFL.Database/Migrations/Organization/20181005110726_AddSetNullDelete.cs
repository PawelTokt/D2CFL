using Microsoft.EntityFrameworkCore.Migrations;

namespace D2CFL.Database.Migrations.Organization
{
    public partial class AddSetNullDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Organization_OrganizationId",
                schema: "organization",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Position_PositionId",
                schema: "organization",
                table: "Player");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Organization_OrganizationId",
                schema: "organization",
                table: "Player",
                column: "OrganizationId",
                principalSchema: "organization",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Position_PositionId",
                schema: "organization",
                table: "Player",
                column: "PositionId",
                principalSchema: "organization",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Organization_OrganizationId",
                schema: "organization",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Position_PositionId",
                schema: "organization",
                table: "Player");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Organization_OrganizationId",
                schema: "organization",
                table: "Player",
                column: "OrganizationId",
                principalSchema: "organization",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Position_PositionId",
                schema: "organization",
                table: "Player",
                column: "PositionId",
                principalSchema: "organization",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
