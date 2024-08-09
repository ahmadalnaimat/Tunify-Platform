using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface ISong
    {
        Task<IEnumerable<Song>> GetAllSongs();
        Task<Song> GetSongById(int id);
        Task AddSong(Song song);
        Task UpdateSong(Song song);
        Task DeleteSong(int id);
    }
}
