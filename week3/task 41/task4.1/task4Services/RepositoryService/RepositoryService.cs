using task4Services.Mapper.DtoModdels;
using task4ModelBase.Interfaces;
using task4ModelBase.Repository;
using AutoMapper;

namespace task4Services.RepositoryService
{
    public class RepositoryService<T> where T : class , IModel
    {
        protected Repository<T> Repo;
        protected IMapper Mapper;

        public IDto Add(IDto dto)
        {
            var data = Mapper.Map<T>(dto);
            Repo.Add(data);

            return dto;
        }

        public bool Delete(int id)
        {
            var data = Repo.Delete(id);

            if (data == null)
                return false;
            else 
                return true;
        }

        public IDto Update(IDto dto)
        {
            var data = Mapper.Map<T>(dto);
            Repo.Update(data);

            return dto;
        }
    }
}
