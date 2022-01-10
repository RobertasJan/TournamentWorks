using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentWorks.Infrastructure.Migrations
{
    public partial class MatchesEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PointsToEarlyWin",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PointsToFinalize",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PointsToWin",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Players",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "PointsToFinalize",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsToWin",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlayerMatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Team = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMatch_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatch_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatch_MatchId",
                table: "PlayerMatch",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatch_PlayerId",
                table: "PlayerMatch",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerMatch");

            migrationBuilder.DropColumn(
                name: "PointsToFinalize",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "PointsToWin",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "LastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "Players",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "PointsToEarlyWin",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PointsToFinalize",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsToWin",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
