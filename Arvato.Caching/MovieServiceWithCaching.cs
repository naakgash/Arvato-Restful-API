using Arvato.Core;
using Arvato.Core.Cores;
using Arvato.Core.DTOs;
using Arvato.Core.Services;
using Arvato.Core.UnitOfWorks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Linq.Expressions;
using System.Text.Json;

namespace Arvato.Caching
{
    public class MovieServiceWithCaching : IMovieService
    {
        private const string CacheMovieKey = "moviesCache";
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distrubutedCache;
        private readonly IMovieRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MovieServiceWithCaching(IMapper mapper, IDistributedCache distrubutedCache, 
            IMovieRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _distrubutedCache = distrubutedCache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (_distrubutedCache.Equals(null))
            {
                string jsonObject = JsonSerializer.Serialize(_repository.GetAll().ToList());
                _distrubutedCache.SetString(CacheMovieKey, jsonObject);
            }
        }

        public async Task<Movie> AddAsync(Movie entitiy)
        {
            throw new NotImplementedException();

        }

        public Task<IEnumerable<Movie>> AddRangeAsync(IEnumerable<Movie> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Movie, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<MovieDto>> GetMovieDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<List<MovieDto>>> GetMovieListAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<List<MovieDto>>> GetMovieListAsync(double rate)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<List<MovieDto>>> GetMovieListAsync(DateTime releaseDate)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Movie> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Movie> Where(Expression<Func<Movie, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task CacheAllMovieAsync()
        {
            var data = await _repository.GetAll().ToListAsync();
            var jsonString = JsonSerializer.Serialize(data);
            _distrubutedCache.SetString(CacheMovieKey, jsonString);
        }
    }
}
