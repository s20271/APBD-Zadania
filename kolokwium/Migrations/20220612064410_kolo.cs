using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium.Migrations
{
    public partial class kolo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musician",
                columns: table => new
                {
                    IdMusician = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician", x => x.IdMusician);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabel",
                columns: table => new
                {
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabel", x => x.IdMusicLabel);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Album_MusicLabel_IdMusicLabel",
                        column: x => x.IdMusicLabel,
                        principalTable: "MusicLabel",
                        principalColumn: "IdMusicLabel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.IdTrack);
                    table.ForeignKey(
                        name: "FK_Track_Album_IdAlbum",
                        column: x => x.IdAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musician_Track",
                columns: table => new
                {
                    IdMusician = table.Column<int>(type: "int", nullable: false),
                    IdTrack = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Track", x => new { x.IdMusician, x.IdTrack });
                    table.ForeignKey(
                        name: "FK_Musician_Track_Musician_IdMusician",
                        column: x => x.IdMusician,
                        principalTable: "Musician",
                        principalColumn: "IdMusician",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musician_Track_Track_IdTrack",
                        column: x => x.IdTrack,
                        principalTable: "Track",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MusicLabel",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[] { 1, "Hard Death Metal" });

            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "NickName" },
                values: new object[] { 1, "Jan", "Kowalski", "Kowal" });

            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "NickName" },
                values: new object[] { 2, "Kamil", "Malinowski", null });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 1, "Kotki", 1, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdAlbum", "TrackName" },
                values: new object[] { 1, 5f, 1, "Wlazl kotek" });

            migrationBuilder.InsertData(
                table: "Musician_Track",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdMusicLabel",
                table: "Album",
                column: "IdMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Track_IdTrack",
                table: "Musician_Track",
                column: "IdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdAlbum",
                table: "Track",
                column: "IdAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musician_Track");

            migrationBuilder.DropTable(
                name: "Musician");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "MusicLabel");
        }
    }
}
