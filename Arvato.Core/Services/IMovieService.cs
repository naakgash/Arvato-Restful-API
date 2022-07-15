using Arvato.Core.DTOs;

namespace Arvato.Core.Services
{
    public interface IMovieService : IGenericService<Movie>
    {
        Task<CustomResponseDto<MovieDto>> GetMovieDetailAsync(int id);
        Task<CustomResponseDto<List<MovieDto>>> GetMovieListAsync(int genreId);
        Task<CustomResponseDto<List<MovieDto>>> GetMovieListAsync(double rate);
        Task<CustomResponseDto<List<MovieDto>>> GetMovieListAsync(DateTime releaseDate);
    }
}
