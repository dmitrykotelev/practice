using AutoMapper;
using task4ModelBase.Models;
using task4ModelBase.Repository;
using task4Services.Mapper.DtoModdels;

namespace task4Services.RepositoryService
{
    public class BookService : RepositoryService
    {
        public BookService(BookRepository<Book> repo, IMapper mapper)
        {
            base.Repo = repo;
            base.Mapper = mapper;
        }

        public BookDto GetById(int id)
        {
            var data = Repo.GetById(id);
            BookDto dto = new BookDto();
            Mapper.Map(dto, data);
            return dto;
        }

        public List<BookDto> GetAll(int id)
        {
            var data = Repo.GetAll();
            BookDto dto = new BookDto();
            List<BookDto> dtoList = new List<BookDto>();
            foreach (var unit in data)
            {
                Mapper.Map(unit, dto);
                dtoList.Add(dto);
            }
            return dtoList;
        }

    }
}
