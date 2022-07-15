namespace Arvato.Core
{
    public partial class Collection
    {
        public Collection()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public int DataId { get; set; }
        public string Name { get; set; } = null!;
        public string PosterPath { get; set; } = null!;
        public string BackdropPath { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
