using Arvato.Core;
using Arvato.Core.Services;
using System.Linq.Expressions;

namespace Arvato.Caching
{
    public class GenreServiceWithCaching : IGenreService
    {
        public Task<Genre> AddAsync(Genre entitiy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Genre>> AddRangeAsync(IEnumerable<Genre> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Genre, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Genre>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Genre entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Genre> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Genre entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Genre> Where(Expression<Func<Genre, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
