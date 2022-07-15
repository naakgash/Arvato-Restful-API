using Arvato.Core;
using Arvato.Core.DTOs;
using AutoMapper;

namespace Arvato.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Collection, CollectionDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();
        }
    }
}
