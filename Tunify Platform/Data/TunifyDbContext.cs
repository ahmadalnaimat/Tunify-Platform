using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : IdentityDbContext<IdentityUser>
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
            #region Album config
            modelBuilder.Entity<Album>()
                .HasKey(pk => pk.AlbumID);
            modelBuilder.Entity<Album>()
                .HasMany(m => m.Songs)
                .WithOne(m => m.Album)
                .HasForeignKey(m => m.AlbumID);
            #endregion
            #region Artist config
            modelBuilder.Entity<Artist>()
                .HasKey(pk => pk.ArtistID);
            modelBuilder.Entity<Artist>()
                .HasMany(m=> m.Songs)
                .WithOne(m => m.Artist)
                .HasForeignKey(m => m.ArtistID);
            #endregion
            #region playlistsongs config
            modelBuilder.Entity<PlaylistSongs>()
                .HasKey(pk => pk.PlaylistSongsID);
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(m => m.Playlist)
                .WithMany(m => m.PlaylistSong)
                .HasForeignKey(ps => ps.PlaylistID);
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(m=>m.Song)
                .WithMany(m => m.PlaylistSong)
                .HasForeignKey(ps => ps.SongID);
            #endregion
            #region song config
            modelBuilder.Entity<Song>()
                .HasKey(pk=> pk.SongID);
            modelBuilder.Entity<Song>()
                .HasOne(m => m.Artist)
                .WithMany(m => m.Songs)
                .HasForeignKey(s => s.ArtistID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region sub config
            modelBuilder.Entity<Subscription>()
                .HasKey(pk=>pk.SubscriptionID);
            modelBuilder.Entity<Subscription>()
                .HasOne(m => m.User)
                .WithOne(m => m.Subscription)
                .HasForeignKey<User>(m => m.SubscriptionID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region User config
            modelBuilder.Entity<User>()
                .HasKey (pk=>pk.UserID);
            modelBuilder.Entity<User>()
                .HasOne(m => m.Subscription)
                .WithOne(m => m.User);
            #endregion
            base.OnModelCreating(modelBuilder);

            // Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            );

            // Seed a default admin user
            var adminUser = new IdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@tunify.com",
                NormalizedEmail = "ADMIN@TUNIFY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = "admin-id"
            };

            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "Admin@123");

            modelBuilder.Entity<IdentityUser>().HasData(adminUser);

            // Assign the admin user to the admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "admin-role-id",
                UserId = "admin-id"
            });
            // Seed data for Artist
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistID = 1, Name = "Artist 1", Bio = "Bio for Artist 1" },
                new Artist { ArtistID = 2, Name = "Artist 2", Bio = "Bio for Artist 2" }
            );

            // Seed data for Album
            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumID = 1, Album_Name = "Album 1", Release_Date = new DateTime(2000, 1, 1), ArtistID = 1 },
                new Album { AlbumID = 2, Album_Name = "Album 2", Release_Date = new DateTime(2001, 1, 1), ArtistID = 2 }
            );

            // Seed data for Song
            modelBuilder.Entity<Song>().HasData(
                new Song { SongID = 1, Title = "Song 1", ArtistID = 1, AlbumID = 1, Durtion = TimeSpan.FromMinutes(3), Genre = "Pop" },
                new Song { SongID = 2, Title = "Song 2", ArtistID = 1, AlbumID = 1, Durtion = TimeSpan.FromMinutes(4), Genre = "Rock" },
                new Song { SongID = 3, Title = "Song 3", ArtistID = 2, AlbumID = 2, Durtion = TimeSpan.FromMinutes(5), Genre = "Jazz" }
            );

            // Seed data for Playlist
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlayListID = 1, PlaylistName = "Playlist 1", UserID = 1, Created_Date = new DateTime(2010, 10, 1) },
                new Playlist { PlayListID = 2, PlaylistName = "Playlist 2", UserID = 1, Created_Date = new DateTime(2011, 10, 1) }
            );

            // Seed data for PlaylistSongs
            modelBuilder.Entity<PlaylistSongs>().HasData(
                new PlaylistSongs { PlaylistSongsID = 1, PlaylistID = 1, SongID = 1 },
                new PlaylistSongs { PlaylistSongsID = 2, PlaylistID = 1, SongID = 2 },
                new PlaylistSongs { PlaylistSongsID = 3, PlaylistID = 2, SongID = 3 }
            );

            // Seed data for User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    Email = "test@test.com",
                    Join_Date = new DateTime(2001, 10, 1),
                    Username = "ahmad",
                    SubscriptionID = 1
                }
            );

            // Seed data for Subscription
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionID = 1, SubscriptionType = "Basic", Price = 9 },
                new Subscription { SubscriptionID = 2, SubscriptionType = "Premium", Price = 10 }
            );
        }
    }
}
