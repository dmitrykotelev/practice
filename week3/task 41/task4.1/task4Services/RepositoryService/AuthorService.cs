using AutoMapper;
using task4ModelBase.Models;
using task4ModelBase.Repository;
using task4Services.Mapper;

namespace task4Services.RepositoryService
{
    public class AuthorService : RepositoryService
    {
        public AuthorService(AuthorRepository<Author> repo, IMapper mapper)
        {
            base.Repo = repo;
            base.Mapper = mapper;
        }

        public AuthorDto GetById(int id)
        {
            var data = Repo.GetById(id);
            AuthorDto dto = new AuthorDto();
            Mapper.Map(dto, data);
            return dto;
        }
        public List<AuthorDto> GetAll(int id)
        {
            var data = Repo.GetAll();
            AuthorDto dto = new AuthorDto();
            List<AuthorDto> dtoList = new List<AuthorDto>();
            foreach (var unit in data)
            {
                Mapper.Map(unit, dto);
                dtoList.Add(dto);
            }
            return dtoList;
        }

    }
}
