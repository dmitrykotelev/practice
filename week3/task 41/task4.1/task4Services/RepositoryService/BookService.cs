using AutoMapper;
using task4ModelBase.Models;
using task4ModelBase.Repository;
using task4Services.Mapper.DtoModdels;

namespace task4Services.RepositoryService
{
    public class BookService : RepositoryService<Book>
    {
        public BookService(BookRepository repo, IMapper mapper)
        {
            base.Repo = repo;
            base.Mapper = mapper;
        }

        public BookDto GetById(int id)
        {
            var data = Repo.GetById(id);
            BookDto dto = Mapper.Map<BookDto>(data);

            return dto;
        }

        public List<BookDto> GetAll()
        {
            var data = Repo.GetAll();
            List<BookDto> dtoList = Mapper.Map<List<BookDto>>(data);

            return dtoList;
        }

    }
}
