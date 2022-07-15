namespace Arvato.Core.Cores
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<Movie> GetMovieDetailAsync(int id);
        Task<List<Genre>> GetMovieListAsync(int genreId);
        Task<List<Movie>> GetMovieListAsync(double rate);
        Task<List<Movie>> GetMovieListAsync(DateTime releaseDate);
    }
}
