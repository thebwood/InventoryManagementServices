using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Game.Infrastructure.Entities
{
    public partial class GamesContext : DbContext
    {
        public GamesContext()
        {
        }

        public GamesContext(DbContextOptions<GamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Games> Games { get; set; } = null!;
        public virtual DbSet<GameFormat> GameFormats { get; set; } = null!;
        public virtual DbSet<GameGenre> GameGenres { get; set; } = null!;
        public virtual DbSet<GameRatings> GameRatings { get; set; } = null!;
        public virtual DbSet<GameType> GameTypes { get; set; } = null!;
        public virtual DbSet<GamesGameFormat> GamesGameFormats { get; set; } = null!;
        public virtual DbSet<GamesGameType> GamesGameTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.GameRatingsId).HasColumnName("GameRatingsID");

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GameFormat>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.GameFormat1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GameFormat");

                entity.Property(e => e.ManufacturerName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.GameGenreId).HasColumnName("GameGenreID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GenreDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GameRatings>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GameType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GamesGameFormat>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.GameFormatId).HasColumnName("GameFormatID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GamesGameType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GameTypesId).HasColumnName("GameTypesID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
