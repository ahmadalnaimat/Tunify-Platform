using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class PlaylistService : IPlaylist
    {
        private readonly TunifyDbContext _context;

        public PlaylistService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task AddPlaylist(Playlist playlist)
        {
           _context.playlists.Add(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlaylist(int id)
        {
            var playlist = await _context.playlists.FindAsync(id);
            if (playlist != null)
            {
                _context.playlists.Remove(playlist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylists()
        {
            return await _context.playlists.ToListAsync();
        }

        public async Task<Playlist> GetPlaylistById(int id)
        {
            return await _context.playlists.FindAsync(id);
        }

        public async Task UpdatePlaylist(Playlist playlist)
        {
            _context.Entry(playlist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
