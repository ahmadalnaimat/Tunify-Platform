using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistService : IArtist
    {
        private readonly TunifyDbContext _context;

        public ArtistService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task AddArtist(Artist artist)
        {
            _context.artists.Add(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtist(int id)
        {
            var artist = await _context.artists.FindAsync(id);
            if (artist != null) 
            {
                _context.artists.Remove(artist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _context.artists.ToListAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            return await _context.artists.FindAsync(id);
        }

        public async Task UpdateArtist(Artist artist)
        {
            _context.Entry(artist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
