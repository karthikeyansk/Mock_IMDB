using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeltaX_Movie_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    actorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actor", x => x.actorId);
                });

            migrationBuilder.CreateTable(
                name: "producers",
                columns: table => new
                {
                    producerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producers", x => x.producerId);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    movieid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    producerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.movieid);
                    table.ForeignKey(
                        name: "FK_movies_producers_producerId",
                        column: x => x.producerId,
                        principalTable: "producers",
                        principalColumn: "producerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movieCasts",
                columns: table => new
                {
                    castId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieId = table.Column<int>(type: "int", nullable: false),
                    actorid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieCasts", x => x.castId);
                    table.ForeignKey(
                        name: "FK_movieCasts_actor_actorid",
                        column: x => x.actorid,
                        principalTable: "actor",
                        principalColumn: "actorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieCasts_movies_movieId",
                        column: x => x.movieId,
                        principalTable: "movies",
                        principalColumn: "movieid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieCasts_actorid",
                table: "movieCasts",
                column: "actorid");

            migrationBuilder.CreateIndex(
                name: "IX_movieCasts_movieId",
                table: "movieCasts",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_producerId",
                table: "movies",
                column: "producerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieCasts");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "producers");
        }
    }
}
