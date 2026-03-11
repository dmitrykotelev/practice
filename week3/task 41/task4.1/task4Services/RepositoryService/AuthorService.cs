using AutoMapper;
using task4ModelBase.Models;
using task4ModelBase.Repository;
using task4Services.Mapper;

namespace task4Services.RepositoryService
{
    public class AuthorService : RepositoryService<Author>
    {
        public AuthorService(AuthorRepository repo, IMapper mapper)
        {
            base.Repo = repo;
            base.Mapper = mapper;
        }

        public AuthorDto GetById(int id)
        {
            var data = Repo.GetById(id);
            AuthorDto dto = Mapper.Map<AuthorDto>(data);

            return dto;
        }
        public List<AuthorDto> GetAll()
        {
            var data = Repo.GetAll();
            List<AuthorDto> dtoList = Mapper.Map<List<AuthorDto>>(data);

            return dtoList;
        }

    }
}
