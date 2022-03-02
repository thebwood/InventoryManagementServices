using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Movie.Infrastructure.Entities
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Formats> Formats { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<MovieFormats> MovieFormats { get; set; }
        public virtual DbSet<MovieGenres> MovieGenres { get; set; }
        public virtual DbSet<MovieRatings> MovieRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formats>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BoxOffice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.MovieRatingsId).HasColumnName("MovieRatingsID");

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovieFormats>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FormatId).HasColumnName("FormatID");

                entity.Property(e => e.FormatName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MovieGenres>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.GenreDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MovieGenreId).HasColumnName("MovieGenreID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");
            });

            modelBuilder.Entity<MovieRatings>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
