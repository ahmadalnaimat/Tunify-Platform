using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : DbContext
    {
        public TunifyDbContext(DbContextOptions<TunifyDbContext> options) : base(options) 
        { 
        }
        public DbSet<User> users { get; set; }
        public DbSet<Album> albums { get; set; }
        public DbSet<Playlist> playlists { get; set; }
        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }
        public DbSet<Song> songs { get; set; }
        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<Artist> artists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // example
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    UserID = 1,
                    Email = "test@test.com",
                    Join_Date = new DateTime(2001, 10, 1),
                    Username="ahmad",
                    Subscription_ID=1 }
                );
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    AlbumID = 1,
                    ArtistID = 1,
                    Durtion = new TimeSpan(0, 20, 0),
                    Genre= "rock",
                    SongID= 1,
                    Title= "test"
                }
            );
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist
                {
                    Created_Date = new DateTime(2010 , 10 ,1),
                    PlayListID = 1,
                    PlaylistName = "test",
                    UserID=1
                }
                );
        }
        public DbSet<Tunify_Platform.Models.Artist> Artist { get; set; } = default!;

    }

}
