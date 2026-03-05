using task4ModelBase.Interfaces;
using task4ModelBase.Repository;
using AutoMapper;
using task4Services.Mapper.DtoModdels;

namespace task4Services.RepositoryService
{
    public class RepositoryService
    {
        protected Repository<IModel> Repo;
        protected IMapper Mapper;

        public void Add(IDto dto)
        {
            IModel data;
            Mapper.Map(dto, data);
            Repo.Add(data);
        }

        public void Delete(int id)
        {
            Repo.Delete(id);
        }

        public void Update(IDto dto)
        {
            Repo.Update(data);
        }
    }
}
