using Arvato.Core;
using Arvato.Core.Cores;
using Arvato.Core.DTOs;
using Arvato.Core.Services;
using Arvato.Core.UnitOfWorks;
using AutoMapper;

namespace Arvato.Service.Services
{
    public class MovieService : GenericService<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieCore;
        private readonly IMapper _mapper;
        public MovieService(IGenericRepository<Movie> core, IUnitOfWork unitOfWork, IMovieRepository movieRepository, IMapper mapper) : base(core, unitOfWork)
        {
            _movieCore = movieRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<MovieDto>> GetMovieDetailAsync(int id)
        {
            var moviesWithDetails = await _movieCore.GetMovieDetailAsync(id);
            var moviesWithDetailsDto = _mapper.Map<MovieDto>(moviesWithDetails);
            return CustomResponseDto<MovieDto>.Success(200, moviesWithDetailsDto);
        }

        public async Task<CustomResponseDto<List<MovieDto>>> GetMovieListAsync(int genreId)
        {
            var moviesWithDetails = await _movieCore.GetMovieListAsync(genreId);
            var moviesWithDetailsDto = _mapper.Map<List<MovieDto>>(moviesWithDetails);
            return CustomResponseDto<List<MovieDto>>.Success(200, moviesWithDetailsDto);
        }

        public async Task<CustomResponseDto<List<MovieDto>>> GetMovieListAsync(double rate)
        {
            var moviesWithDetails = await _movieCore.GetMovieListAsync(rate);
            var moviesWithDetailsDto = _mapper.Map<List<MovieDto>>(moviesWithDetails);
            return CustomResponseDto<List<MovieDto>>.Success(200, moviesWithDetailsDto);
        }

        public async Task<CustomResponseDto<List<MovieDto>>> GetMovieListAsync(DateTime releaseDate)
        {
            var moviesWithDetails = await _movieCore.GetMovieListAsync(releaseDate);
            var moviesWithDetailsDto = _mapper.Map<List<MovieDto>>(moviesWithDetails);
            return CustomResponseDto<List<MovieDto>>.Success(200, moviesWithDetailsDto);
        }
    }
}
