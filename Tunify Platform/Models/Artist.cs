namespace Tunify_Platform.Models
{
    public class Artist
    {
        public int ArtistID {  get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public Album Album { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
