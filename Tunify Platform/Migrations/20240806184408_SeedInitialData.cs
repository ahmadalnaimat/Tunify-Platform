using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "PlayListID", "Created_Date", "PlaylistName", "UserID" },
                values: new object[] { 1, new DateTime(2010, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", 1 });

            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "SongID", "AlbumID", "ArtistID", "Durtion", "Genre", "Title" },
                values: new object[] { 1, 1, 1, new TimeSpan(0, 0, 20, 0, 0), "rock", "test" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserID", "Email", "Join_Date", "Subscription_ID", "Username" },
                values: new object[] { 1, "test@test.com", new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ahmad" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlayListID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "SongID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "UserID",
                keyValue: 1);
        }
    }
}
