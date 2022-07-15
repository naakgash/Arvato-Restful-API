using System;
using System.Collections.Generic;

namespace Arvato.Repository
{
    public partial class Rawdatum
    {
        public bool Adult { get; set; }
        public string? BelongsToCollection { get; set; }
        public long Budget { get; set; }
        public string Genres { get; set; } = null!;
        public string? Homepage { get; set; }
        public long Id { get; set; }
        public string? ImdbId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; } = null!;
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? ProductionCompanies { get; set; }
        public string? ProductionCountries { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public decimal? Runtime { get; set; }
        public string? SpokenLanguages { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public string? Video { get; set; }
        public decimal? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
    }
}
