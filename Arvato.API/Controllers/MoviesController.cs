using Arvato.Core;
using Arvato.Core.DTOs;
using Arvato.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arvato.API.Controllers
{
    public class MoviesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _service;

        public MoviesController(IMapper mapper, IMovieService sservice)
        {
            _mapper = mapper;
            _service = sservice;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieWithAllDetails(int id)
        {
            return CreateActionResult(await _service.GetMovieDetailAsync(id));
        }

        [HttpGet("byGenre/{genreId}")]
        public async Task<IActionResult> GetMoviesByGenreId(int genreId)
        {
            return CreateActionResult(await _service.GetMovieListAsync(genreId));
        }
        /*
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await _service.GetAllAsync();
            var moviesDtos = _mapper.Map<List<MovieSeedDto>>(movies.ToList());

            return CreateActionResult(CustomResponseDto<List<MovieSeedDto>>.Success(200, moviesDtos));
        }
        */
        [HttpPost]
        public async Task<IActionResult> Save(MovieDto movieDto)
        {
            var movie = await _service.AddAsync(_mapper.Map<Movie>(movieDto));
            var moviesDto = _mapper.Map<MovieDto>(movie);

            return CreateActionResult(CustomResponseDto<MovieDto>.Success(201, moviesDto));
        }
        /*
        [HttpPut]
        public async Task<IActionResult> Update(MovieDto movieDto)
        {
            await _service.UpdateAsync(_mapper.Map<Movie>(movieDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        */
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(movie);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
