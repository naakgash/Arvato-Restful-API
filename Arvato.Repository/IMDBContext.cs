using Microsoft.EntityFrameworkCore;
using Arvato.Core;
using System.Reflection;

namespace Arvato.Repository
{
    public partial class IMDBContext : DbContext
    {
        public IMDBContext()
        {
        }

        public IMDBContext(DbContextOptions<IMDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Rawdatum> Rawdata { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=IMDB;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.HasMany(d => d.Movies)
                    .WithMany(p => p.Collections)
                    .UsingEntity<Dictionary<string, object>>(
                        "CollectionMovie",
                        l => l.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                        r => r.HasOne<Collection>().WithMany().HasForeignKey("CollectionsId"),
                        j =>
                        {
                            j.HasKey("CollectionsId", "MoviesId");

                            j.ToTable("CollectionMovie");

                            j.HasIndex(new[] { "MoviesId" }, "IX_CollectionMovie_MoviesId");
                        });
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasMany(d => d.Movies)
                    .WithMany(p => p.Countries)
                    .UsingEntity<Dictionary<string, object>>(
                        "CountryMovie",
                        l => l.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                        r => r.HasOne<Country>().WithMany().HasForeignKey("CountriesId"),
                        j =>
                        {
                            j.HasKey("CountriesId", "MoviesId");

                            j.ToTable("CountryMovie");

                            j.HasIndex(new[] { "MoviesId" }, "IX_CountryMovie_MoviesId");
                        });
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasMany(d => d.Movies)
                    .WithMany(p => p.Genres)
                    .UsingEntity<Dictionary<string, object>>(
                        "GenreMovie",
                        l => l.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                        r => r.HasOne<Genre>().WithMany().HasForeignKey("GenresId"),
                        j =>
                        {
                            j.HasKey("GenresId", "MoviesId");

                            j.ToTable("GenreMovie");

                            j.HasIndex(new[] { "MoviesId" }, "IX_GenreMovie_MoviesId");
                        });
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasMany(d => d.SpokenLanguages)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "LanguageMovie",
                        l => l.HasOne<Language>().WithMany().HasForeignKey("SpokenLanguagesId"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                        j =>
                        {
                            j.HasKey("MoviesId", "SpokenLanguagesId");

                            j.ToTable("LanguageMovie");

                            j.HasIndex(new[] { "SpokenLanguagesId" }, "IX_LanguageMovie_SpokenLanguagesId");
                        });
            });

            modelBuilder.Entity<Rawdatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rawdata");

                entity.Property(e => e.Adult).HasColumnName("adult");

                entity.Property(e => e.BelongsToCollection)
                    .HasMaxLength(184)
                    .HasColumnName("belongs_to_collection");

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.Genres)
                    .HasMaxLength(264)
                    .HasColumnName("genres");

                entity.Property(e => e.Homepage)
                    .HasMaxLength(242)
                    .HasColumnName("homepage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImdbId)
                    .HasMaxLength(9)
                    .HasColumnName("imdb_id");

                entity.Property(e => e.OriginalLanguage)
                    .HasMaxLength(5)
                    .HasColumnName("original_language");

                entity.Property(e => e.OriginalTitle)
                    .HasMaxLength(109)
                    .HasColumnName("original_title");

                entity.Property(e => e.Overview)
                    .HasMaxLength(1000)
                    .HasColumnName("overview");

                entity.Property(e => e.Popularity).HasColumnName("popularity");

                entity.Property(e => e.PosterPath)
                    .HasMaxLength(35)
                    .HasColumnName("poster_path");

                entity.Property(e => e.ProductionCompanies)
                    .HasMaxLength(1252)
                    .HasColumnName("production_companies");

                entity.Property(e => e.ProductionCountries)
                    .HasMaxLength(1039)
                    .HasColumnName("production_countries");

                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");

                entity.Property(e => e.Revenue).HasColumnName("revenue");

                entity.Property(e => e.Runtime)
                    .HasPrecision(6, 1)
                    .HasColumnName("runtime");

                entity.Property(e => e.SpokenLanguages)
                    .HasMaxLength(765)
                    .HasColumnName("spoken_languages");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .HasColumnName("status");

                entity.Property(e => e.Tagline)
                    .HasMaxLength(297)
                    .HasColumnName("tagline");

                entity.Property(e => e.Title)
                    .HasMaxLength(105)
                    .HasColumnName("title");

                entity.Property(e => e.Video)
                    .HasMaxLength(5)
                    .HasColumnName("video");

                entity.Property(e => e.VoteAverage)
                    .HasPrecision(4, 1)
                    .HasColumnName("vote_average");

                entity.Property(e => e.VoteCount).HasColumnName("vote_count");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
