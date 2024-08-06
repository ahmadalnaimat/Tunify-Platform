namespace Tunify_Platform.Models
{
    public class Playlist
    {
        public int PlayListID { get; set; }
        public string PlaylistName { get; set; }
        public int UserID { get; set; }
        public DateTime Created_Date { get; set; }
    }
}
