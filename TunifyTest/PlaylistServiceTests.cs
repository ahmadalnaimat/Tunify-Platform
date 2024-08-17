using Microsoft.EntityFrameworkCore;
using Moq;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Services;
namespace TunifyTests
{
    public class PlaylistServiceTests
    {
        [Fact]
        public async Task GetSongsInPlaylistAsync_ShouldReturnCorrectSongs()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TunifyDbContext>()
                .UseInMemoryDatabase(databaseName: "TunifyTestDatabase")
                .Options;

            using (var context = new TunifyDbContext(options))
            {
                context.playlists.Add(new Playlist
                {
                    PlayListID = 1,
                    PlaylistName = "My Playlist",
                    PlaylistSong = new List<PlaylistSongs>
                {
                    new PlaylistSongs
                    {
                        Song = new Song
                        {
                            SongID = 1,
                            Title = "Song 1",
                            Artist = new Artist
                            {
                                ArtistID = 1,
                                Name = "Artist 1",
                                Bio = "Bio of Artist 1", // Ensure Bio is set
                            },
                            Album = new Album
                            {
                                AlbumID = 1,
                                Album_Name = "Album 1"
                            },
                            Durtion = new TimeSpan(0, 3, 45),
                            Genre = "Pop"
                        }
                    },
                    new PlaylistSongs
                    {
                        Song = new Song
                        {
                            SongID = 2,
                            Title = "Song 2",
                            Artist = new Artist
                            {
                                ArtistID = 2,
                                Name = "Artist 2",
                                Bio = "Bio of Artist 2", // Ensure Bio is set
                            },
                            Album = new Album
                            {
                                AlbumID = 2,
                                Album_Name = "Album 2"
                            },
                            Durtion = new TimeSpan(0, 4, 20),
                            Genre = "Rock"
                        }
                    }
                    }
                });

                await context.SaveChangesAsync();
            }

            using (var context = new TunifyDbContext(options))
            {
                var service = new PlaylistService(context);

                // Act
                var songs = await service.GetSongsForPlaylist(1);

                // Assert
                Assert.Equal(2, songs.Count());
                Assert.Contains(songs, s => s.Title == "Song 1");
                Assert.Contains(songs, s => s.Title == "Song 2");
            }
        }
    }
}