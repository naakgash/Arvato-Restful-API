using Arvato.Core;
using Arvato.Core.Cores;
using Microsoft.EntityFrameworkCore;

namespace Arvato.Repository.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository 
    {
        public MovieRepository(IMDBContext context) : base(context)
        {
        }

        public async Task<Movie> GetMovieDetailAsync(int id)
        {
            return await _context.Movies
                .Where(x => x.Id == id)
                .Include(x => x.Collections)
                .Include(x => x.Genres)
                .Include(x => x.Countries)
                .Include(x => x.SpokenLanguages)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Genre>> GetMovieListAsync(int genreId)
        {
            return await _context.Genres.Where(x => x.Id == genreId)
                .Include(x => x.Movies).ThenInclude(x => x.Collections)
                .Include(x => x.Movies).ThenInclude(x => x.Countries)
                .Include(x => x.Movies).ThenInclude(x => x.SpokenLanguages)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMovieListAsync(double rate)
        {
            return await _context.Movies
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMovieListAsync(DateTime releaseDate)
        {
            return await _context.Movies
                .ToListAsync();
        }
    }
}
