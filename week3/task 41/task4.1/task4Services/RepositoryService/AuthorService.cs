using AutoMapper;
using task4ModelBase.Models;
using task4ModelBase.Repository;
using task4Services.Mapper;

namespace task4Services.RepositoryService
{
    public class AuthorService : RepositoryService<Author, AuthorDto>
    {
        public AuthorService(AuthorRepository repo, IMapper mapper) : base(repo, mapper) { }
    }
}
