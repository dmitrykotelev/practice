using AutoMapper;
using task4ModelBase.Models;
using task4ModelBase.Repository;
using task4Services.Mapper.DtoModdels;

namespace task4Services.RepositoryService
{
    public class BookService : RepositoryService<Book, BookDto>
    {
        public BookService(BookRepository repo, IMapper mapper) : base(repo, mapper) { }

        public List<BookDto> FindBooksByYear(DateTime date)
        {
            List<Book> FindedData = _repo.GetAll().Where(x => x.PublishedYear.Year <= date.Year).ToList();
            return _mapper.Map<List<BookDto>>(FindedData);
        }
    }
}