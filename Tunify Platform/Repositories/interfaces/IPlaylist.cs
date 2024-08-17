using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface IPlaylist
    {
        Task<IEnumerable<Playlist>> GetAllPlaylists();
        Task<Playlist> GetPlaylistById(int id);
        Task AddPlaylist(Playlist playlist);
        Task UpdatePlaylist(Playlist playlist);
        Task DeletePlaylist(int id);
        Task AddSongToPlaylist(int playlistId, int songId);
        Task<IEnumerable<Song>> GetSongsForPlaylist(int playlistId);
    }
}
