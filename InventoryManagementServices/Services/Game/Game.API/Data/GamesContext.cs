using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Game.API.Data
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
        public virtual DbSet<GameFormats> GameFormats { get; set; } = null!;
        public virtual DbSet<GameRatings> GameRatings { get; set; } = null!;
        public virtual DbSet<GameTypes> GameTypes { get; set; } = null!;
        public virtual DbSet<GamesGameFormats> GamesGameFormats { get; set; } = null!;
        public virtual DbSet<GamesGameTypes> GamesGameTypes { get; set; } = null!;
        public IConfiguration Configuration { get;}

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

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GameFormats>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.GameFormat1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GameFormat");
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

            modelBuilder.Entity<GameTypes>(entity =>
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

            modelBuilder.Entity<GamesGameFormats>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.GameFormatId).HasColumnName("GameFormatID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GamesGameTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GameTypesId).HasColumnName("GameTypesID");

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
