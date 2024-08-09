using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISong _songService;  // Changed from _songsrepositorie to _songService

        public SongsController(ISong songService)  // Constructor now takes ISong
        {
            _songService = songService;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            var songs = await _songService.GetAllSongs();  // Changed to use repository
            if (songs == null)
            {
                return NotFound();
            }
            return Ok(songs);
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _songService.GetSongById(id);  // Changed to use repository
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.SongID)
            {
                return BadRequest();
            }

            var existingSong = await _songService.GetSongById(id);  // Check if song exists
            if (existingSong == null)
            {
                return NotFound();
            }

            await _songService.UpdateSong(song);  // Changed to use repository
            return NoContent();
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            if (song == null)
            {
                return BadRequest();
            }

            await _songService.AddSong(song);  // Changed to use repository
            return CreatedAtAction(nameof(GetSong), new { id = song.SongID }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var existingSong = await _songService.GetSongById(id);  // Check if song exists
            if (existingSong == null)
            {
                return NotFound();
            }

            await _songService.DeleteSong(id);  // Changed to use repository
            return NoContent();
        }
    }
}
