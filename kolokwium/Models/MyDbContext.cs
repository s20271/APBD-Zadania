using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MyDbContext()
        {
        }

        public DbSet<Musician> Musician { get; set; }
        public DbSet<Musician_Track> Musician_Track { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s20271;Integrated Security=True ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(p =>
            {
                p.HasKey(e => e.IdMusician);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                p.Property(e => e.NickName).HasMaxLength(20);
                p.HasData(new Musician { IdMusician = 1, FirstName = "Jan", LastName = "Kowalski", NickName = "Kowal" });
                p.HasData(new Musician { IdMusician = 2, FirstName = "Kamil", LastName = "Malinowski" });
            });

            modelBuilder.Entity<Musician_Track>(p =>
            {
                p.HasKey(e => new { e.IdMusician, e.IdTrack });
                p.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician);
                p.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);
                p.HasData(new Musician_Track { IdMusician = 1, IdTrack = 1 });
            });

            modelBuilder.Entity<Track>(p =>
            {
                p.HasKey(e => e.IdTrack);
                p.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                p.Property(e => e.Duration).IsRequired();
                p.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdAlbum);

                p.HasData(new Track { IdTrack = 1, TrackName = "Wlazl kotek", Duration = 5, IdAlbum = 1});
            });

            modelBuilder.Entity<Album>(p =>
            {
                p.HasKey(e => e.IdAlbum);
                p.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                p.Property(e => e.PublishDate).IsRequired();
                p.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                p.HasData(new Album{IdAlbum = 1, AlbumName = "Kotki", PublishDate = DateTime.Parse("2022-01-10"), IdMusicLabel = 1 });
            });

            modelBuilder.Entity<MusicLabel>(p =>
            {
                p.HasKey(e => e.IdMusicLabel);
                p.Property(e => e.Name).IsRequired().HasMaxLength(50);
               
                p.HasData(new MusicLabel { IdMusicLabel = 1, Name = "Hard Death Metal"});
            });
        }
    }
}