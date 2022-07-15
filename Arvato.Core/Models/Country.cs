namespace Arvato.Core
{
    public partial class Country
    {
        public Country()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Abbreviation { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
