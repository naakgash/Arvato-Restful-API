namespace Arvato.Core
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public int DataId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
