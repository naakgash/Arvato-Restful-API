namespace Arvato.Core
{
    public partial class Movie
    {
        public Movie()
        {
            Collections = new HashSet<Collection>();
            Countries = new HashSet<Country>();
            Genres = new HashSet<Genre>();
            SpokenLanguages = new HashSet<Language>();
        }

        public int Id { get; set; }
        public bool Adult { get; set; }
        public long Budget { get; set; }
        public string? Homepage { get; set; }
        public long DataId { get; set; }
        public string? ImdbId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public decimal? Runtime { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public string? Video { get; set; }
        public decimal? VoteAverage { get; set; }
        public int? VoteCount { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Language> SpokenLanguages { get; set; }
    }
}
