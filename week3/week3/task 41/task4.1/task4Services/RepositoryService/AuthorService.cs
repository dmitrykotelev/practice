using AutoMapper;
using task4Services.Mapper;
using task4ModelBase.Models;
using task4ModelBase.Repository;

namespace task4Services.RepositoryService
{
    public class AuthorService : RepositoryService<Author, AuthorDto>
    {
        public AuthorService(AuthorRepository repo, IMapper mapper) : base(repo, mapper) { }
    }
}