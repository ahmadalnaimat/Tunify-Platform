namespace Tunify_Platform.Models
{
    public class PlaylistSongs
    {
        public int PlaylistSongsID { get; set; }
        public int PlaylistID { get; set; }
        public Playlist Playlist { get; set; }
        public int SongID { get; set; }
        public Song Song { get; set; }
    }
}
