using Moq;
using Xunit;
using Tunify_Platform.Repositories.Services;
using Tunify_Platform.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class PlaylistServiceTests
{
    private readonly Mock<TunifyDbContext> _mockContext;
    private readonly PlaylistService _playlistService;

    public PlaylistServiceTests()
    {
        // Set up a mock of the DbContext
        _mockContext = new Mock<TunifyDbContext>();

        // Pass the mock context to your service
        _playlistService = new PlaylistService(_mockContext.Object);
    }

    [Fact]
    public async Task AddSongToPlaylist_ShouldAddSongToPlaylist()
    {
        // Arrange
        var playlistId = 1;
        var songId = 1;

        var playlist = new Playlist { PlaylistID = playlistId, Playlist_Name = "Test Playlist" };
        var song = new Song { SongID = songId, Title = "Test Song" };

        // Mock the DbSet.FindAsync method to return the playlist and song
        _mockContext.Setup(c => c.Playlists.FindAsync(playlistId)).ReturnsAsync(playlist);
        _mockContext.Setup(c => c.Songs.FindAsync(songId)).ReturnsAsync(song);

        // Act
        await _playlistService.AddSongToPlaylist(playlistId, songId);

        // Assert
        Assert.Contains(song, playlist.PlaylistSongs.Select(ps => ps.Song));
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }
}
