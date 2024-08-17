using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;
namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtist _artistService;

        public ArtistsController(IArtist artistService)
        {
            _artistService = artistService;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            var artists = await _artistService.GetAllArtists();
            if (artists == null || !artists.Any())
            {
                return NotFound();
            }
            return Ok(artists);
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _artistService.GetArtistById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        // PUT: api/Artists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.ArtistID)
            {
                return BadRequest();
            }

            try
            {
                await _artistService.UpdateArtist(artist);
            }
            catch (Exception)
            {
                if (await _artistService.GetArtistById(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Artists
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            if (artist == null)
            {
                return BadRequest();
            }

            await _artistService.AddArtist(artist);
            return CreatedAtAction("GetArtist", new { id = artist.ArtistID }, artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _artistService.GetArtistById(id);
            if (artist == null)
            {
                return NotFound();
            }

            await _artistService.DeleteArtist(id);
            return NoContent();
        }
        [HttpGet("{artistId}/songs")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsByArtist(int artistId)
        {
            try
            {
                var songs = await _artistService.GetSongsByArtist(artistId);
                if (songs == null || !songs.Any())
                {
                    return NotFound();
                }
                return Ok(songs);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("artists/{artistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
        {
            try
            {
                await _artistService.AddSongToArtist(artistId, songId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
