using AutoMapper;
using task4ModelBase.Interfaces;
using task4ModelBase.Repository;

namespace task4Services.RepositoryService
{
    abstract public class RepositoryService<T,TT> where T : class , IModel
                                         where TT : class
    {
        protected readonly Repository<T> _repo;
        protected readonly IMapper _mapper;

        public RepositoryService(Repository<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public TT GetById(int id)
        {
            var data = _repo.GetById(id);
            TT dto = _mapper.Map<TT>(data);

            return _mapper.Map<TT>(_repo.GetById(id));
        }

        public List<TT> GetAll()
        {
            var data = _repo.GetAll();
            List<TT> dtoList = _mapper.Map<List<TT>>(data);

            return dtoList;
        }

        public TT Add(TT dto)
        {
            var data = _mapper.Map<T>(dto);

            return _mapper.Map<TT>(_repo.Add(data));
        }

        public TT Update(TT dto)
        {
            var data = _mapper.Map<T>(dto);

            return _mapper.Map<TT>(_repo.Update(data));
        }

        public bool Delete(int id)
        {
            var data = _repo.Delete(id);

            if (data == null)
                return false;
            else 
                return true;
        }
    }
}