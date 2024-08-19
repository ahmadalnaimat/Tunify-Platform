using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    ArtistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artists", x => x.ArtistID);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    SubscriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.SubscriptionID);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Album_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Release_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_albums_artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "artists",
                        principalColumn: "ArtistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Join_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_users_subscriptions_SubscriptionID",
                        column: x => x.SubscriptionID,
                        principalTable: "subscriptions",
                        principalColumn: "SubscriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "songs",
                columns: table => new
                {
                    SongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistID = table.Column<int>(type: "int", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    Durtion = table.Column<TimeSpan>(type: "time", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songs", x => x.SongID);
                    table.ForeignKey(
                        name: "FK_songs_albums_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "albums",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_songs_artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "artists",
                        principalColumn: "ArtistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    PlayListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.PlayListID);
                    table.ForeignKey(
                        name: "FK_playlists_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistSongs",
                columns: table => new
                {
                    PlaylistSongsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSongs", x => x.PlaylistSongsID);
                    table.ForeignKey(
                        name: "FK_PlaylistSongs_playlists_PlaylistID",
                        column: x => x.PlaylistID,
                        principalTable: "playlists",
                        principalColumn: "PlayListID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSongs_songs_SongID",
                        column: x => x.SongID,
                        principalTable: "songs",
                        principalColumn: "SongID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "artists",
                columns: new[] { "ArtistID", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Bio for Artist 1", "Artist 1" },
                    { 2, "Bio for Artist 2", "Artist 2" }
                });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "SubscriptionID", "Price", "SubscriptionType" },
                values: new object[,]
                {
                    { 1, 9, "Basic" },
                    { 2, 10, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "AlbumID", "Album_Name", "ArtistID", "Release_Date" },
                values: new object[,]
                {
                    { 1, "Album 1", 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Album 2", 2, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserID", "Email", "Join_Date", "SubscriptionID", "Username" },
                values: new object[] { 1, "test@test.com", new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ahmad" });

            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "PlayListID", "Created_Date", "PlaylistName", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Playlist 1", 1 },
                    { 2, new DateTime(2011, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Playlist 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "SongID", "AlbumID", "ArtistID", "Durtion", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 0, 3, 0, 0), "Pop", "Song 1" },
                    { 2, 1, 1, new TimeSpan(0, 0, 4, 0, 0), "Rock", "Song 2" },
                    { 3, 2, 2, new TimeSpan(0, 0, 5, 0, 0), "Jazz", "Song 3" }
                });

            migrationBuilder.InsertData(
                table: "PlaylistSongs",
                columns: new[] { "PlaylistSongsID", "PlaylistID", "SongID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_albums_ArtistID",
                table: "albums",
                column: "ArtistID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_playlists_UserID",
                table: "playlists",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_PlaylistID",
                table: "PlaylistSongs",
                column: "PlaylistID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_SongID",
                table: "PlaylistSongs",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_songs_AlbumID",
                table: "songs",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_songs_ArtistID",
                table: "songs",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_users_SubscriptionID",
                table: "users",
                column: "SubscriptionID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistSongs");

            migrationBuilder.DropTable(
                name: "playlists");

            migrationBuilder.DropTable(
                name: "songs");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "artists");
        }
    }
}
