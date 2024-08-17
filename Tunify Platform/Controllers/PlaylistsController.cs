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
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylist _playlistService;

        public PlaylistsController(IPlaylist playlistService)
        {
            _playlistService = playlistService;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            var playlists = await _playlistService.GetAllPlaylists();
            if (playlists == null || !playlists.Any())
            {
                return NotFound();
            }
            return Ok(playlists);
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
            var playlist = await _playlistService.GetPlaylistById(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return Ok(playlist);
        }

        // PUT: api/Playlists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            if (id != playlist.PlayListID)
            {
                return BadRequest();
            }

            try
            {
                await _playlistService.UpdatePlaylist(playlist);
            }
            catch (Exception)
            {
                if (await _playlistService.GetPlaylistById(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Playlists
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            if (playlist == null)
            {
                return BadRequest();
            }

            await _playlistService.AddPlaylist(playlist);
            return CreatedAtAction("GetPlaylist", new { id = playlist.PlayListID }, playlist);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var playlist = await _playlistService.GetPlaylistById(id);
            if (playlist == null)
            {
                return NotFound();
            }

            await _playlistService.DeletePlaylist(id);
            return NoContent();
        }
        // POST: api/Playlists/{playlistId}/songs/{songId}
        [HttpPost("artists/{artistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            try
            {
                await _playlistService.AddSongToPlaylist(playlistId, songId);
                return Ok("Song added to playlist successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Playlists/{playlistId}/songs
        [HttpGet("{playlistId}/songs")]
        public async Task<IActionResult> GetSongsInPlaylist(int playlistId)
        {
            try
            {
                var songs = await _playlistService.GetSongsForPlaylist(playlistId);

                if (songs == null || !songs.Any())
                {
                    return NotFound("No songs found for this playlist.");
                }

                return Ok(songs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
