using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface IArtist
    {
        Task<IEnumerable<Artist>> GetAllArtists();
        Task<Artist> GetArtistById(int id);
        Task AddArtist(Artist artist);
        Task UpdateArtist(Artist artist);
        Task DeleteArtist(int id);
        Task AddSongToArtist(int artistId, int songId);
        Task<IEnumerable<Song>> GetSongsByArtist(int artistId);

    }
}
