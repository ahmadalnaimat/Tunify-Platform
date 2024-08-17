﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tunify_Platform.Data;

#nullable disable

namespace Tunify_Platform.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    partial class TunifyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tunify_Platform.Models.Album", b =>
                {
                    b.Property<int>("AlbumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumID"));

                    b.Property<string>("Album_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Release_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("AlbumID");

                    b.HasIndex("ArtistID")
                        .IsUnique();

                    b.ToTable("albums");

                    b.HasData(
                        new
                        {
                            AlbumID = 1,
                            Album_Name = "Album 1",
                            ArtistID = 1,
                            Release_Date = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AlbumID = 2,
                            Album_Name = "Album 2",
                            ArtistID = 2,
                            Release_Date = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Artist", b =>
                {
                    b.Property<int>("ArtistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistID"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistID");

                    b.ToTable("artists");

                    b.HasData(
                        new
                        {
                            ArtistID = 1,
                            Bio = "Bio for Artist 1",
                            Name = "Artist 1"
                        },
                        new
                        {
                            ArtistID = 2,
                            Bio = "Bio for Artist 2",
                            Name = "Artist 2"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlist", b =>
                {
                    b.Property<int>("PlayListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayListID"));

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlaylistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PlayListID");

                    b.HasIndex("UserID");

                    b.ToTable("playlists");

                    b.HasData(
                        new
                        {
                            PlayListID = 1,
                            Created_Date = new DateTime(2010, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Playlist 1",
                            UserID = 1
                        },
                        new
                        {
                            PlayListID = 2,
                            Created_Date = new DateTime(2011, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Playlist 2",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.PlaylistSongs", b =>
                {
                    b.Property<int>("PlaylistSongsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistSongsID"));

                    b.Property<int>("PlaylistID")
                        .HasColumnType("int");

                    b.Property<int>("SongID")
                        .HasColumnType("int");

                    b.HasKey("PlaylistSongsID");

                    b.HasIndex("PlaylistID");

                    b.HasIndex("SongID");

                    b.ToTable("PlaylistSongs");

                    b.HasData(
                        new
                        {
                            PlaylistSongsID = 1,
                            PlaylistID = 1,
                            SongID = 1
                        },
                        new
                        {
                            PlaylistSongsID = 2,
                            PlaylistID = 1,
                            SongID = 2
                        },
                        new
                        {
                            PlaylistSongsID = 3,
                            PlaylistID = 2,
                            SongID = 3
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Song", b =>
                {
                    b.Property<int>("SongID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongID"));

                    b.Property<int>("AlbumID")
                        .HasColumnType("int");

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Durtion")
                        .HasColumnType("time");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongID");

                    b.HasIndex("AlbumID");

                    b.HasIndex("ArtistID");

                    b.ToTable("songs");

                    b.HasData(
                        new
                        {
                            SongID = 1,
                            AlbumID = 1,
                            ArtistID = 1,
                            Durtion = new TimeSpan(0, 0, 3, 0, 0),
                            Genre = "Pop",
                            Title = "Song 1"
                        },
                        new
                        {
                            SongID = 2,
                            AlbumID = 1,
                            ArtistID = 1,
                            Durtion = new TimeSpan(0, 0, 4, 0, 0),
                            Genre = "Rock",
                            Title = "Song 2"
                        },
                        new
                        {
                            SongID = 3,
                            AlbumID = 2,
                            ArtistID = 2,
                            Durtion = new TimeSpan(0, 0, 5, 0, 0),
                            Genre = "Jazz",
                            Title = "Song 3"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionID"));

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SubscriptionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscriptionID");

                    b.ToTable("subscriptions");

                    b.HasData(
                        new
                        {
                            SubscriptionID = 1,
                            Price = 9,
                            SubscriptionType = "Basic"
                        },
                        new
                        {
                            SubscriptionID = 2,
                            Price = 10,
                            SubscriptionType = "Premium"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Join_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("SubscriptionID")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "test@test.com",
                            Join_Date = new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubscriptionID = 1,
                            Username = "ahmad"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Album", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Artist", "Artist")
                        .WithOne("Album")
                        .HasForeignKey("Tunify_Platform.Models.Album", "ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlist", b =>
                {
                    b.HasOne("Tunify_Platform.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tunify_Platform.Models.PlaylistSongs", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Playlist", "Playlist")
                        .WithMany("PlaylistSong")
                        .HasForeignKey("PlaylistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tunify_Platform.Models.Song", "Song")
                        .WithMany("PlaylistSong")
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Song", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tunify_Platform.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Tunify_Platform.Models.User", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Subscription", "Subscription")
                        .WithOne("User")
                        .HasForeignKey("Tunify_Platform.Models.User", "SubscriptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Artist", b =>
                {
                    b.Navigation("Album")
                        .IsRequired();

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistSong");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Song", b =>
                {
                    b.Navigation("PlaylistSong");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Subscription", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Tunify_Platform.Models.User", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
