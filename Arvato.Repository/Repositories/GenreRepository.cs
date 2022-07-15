using Arvato.Core;
using Arvato.Core.Repositories;

namespace Arvato.Repository.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IMDBContext context) : base(context)
        {
        }
    }
}
