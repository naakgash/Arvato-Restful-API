using Arvato.Core;
using Arvato.Core.Cores;
using Arvato.Core.Services;
using Arvato.Core.UnitOfWorks;

namespace Arvato.Service.Services
{
    public class GenreService : GenericService<Genre>, IGenreService
    {
        public GenreService(IGenericRepository<Genre> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
