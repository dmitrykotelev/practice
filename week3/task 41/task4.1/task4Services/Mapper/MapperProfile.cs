using AutoMapper;
using task4ModelBase.Models;
using task4Services.Mapper.DtoModdels;

namespace task4Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
