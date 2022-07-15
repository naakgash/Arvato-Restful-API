using Arvato.Core;
using Arvato.Core.DTOs;
using Arvato.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Arvato.API.Controllers
{
    public class GenresController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<Genre> _service;

        public GenresController(IMapper mapper, IGenericService<Genre> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var genres = await _service.GetAllAsync();
            var genreDto = _mapper.Map<List<GenreDto>>(genres.ToList());

            return CreateActionResult(CustomResponseDto<List<GenreDto>>.Success(200, genreDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(GenreDto GenreDto)
        {
            var genre = await _service.AddAsync(_mapper.Map<Genre>(GenreDto));
            var genreDto = _mapper.Map<GenreDto>(genre);

            return CreateActionResult(CustomResponseDto<GenreDto>.Success(201, genreDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(GenreDto GenreDto)
        {
            await _service.UpdateAsync(_mapper.Map<Genre>(GenreDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var genre = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(genre);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
