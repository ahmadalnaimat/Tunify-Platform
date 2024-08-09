using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class SongService : ISong
    {
        private readonly TunifyDbContext _context;

        public SongService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task AddSong(Song song)
        {
            _context.songs.Add(song);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSong(int id)
        {
            var song = await _context.songs.FindAsync(id);
            if (song != null)
            {
                _context.songs.Remove(song);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            return await _context.songs.ToListAsync();
        }

        public async Task<Song> GetSongById(int id)
        {
            return await _context.songs.FindAsync(id);
        }

        public async Task UpdateSong(Song song)
        {
            _context.Entry(song).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
