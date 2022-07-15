namespace Arvato.Core.DTOs
{
    public class MovieDto
    {
        public bool Adult { get; set; }
        public long Budget { get; set; }
        public string? Homepage { get; set; }
        public string? ImdbId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public string? PosterPath { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public decimal? Runtime { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public string? Video { get; set; }

        public virtual ICollection<CollectionDto> Collections { get; set; }
        public virtual ICollection<CountryDto> Countries { get; set; }
        public virtual ICollection<GenreDto> Genres { get; set; }
        public virtual ICollection<LanguageDto> SpokenLanguages { get; set; }
    }
}
