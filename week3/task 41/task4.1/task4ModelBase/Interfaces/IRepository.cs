namespace task4ModelBase.Interfaces
{
    public interface IRepository<T> where T : class, IModel
    {
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public T Add(T model);
        public T Delete(int id);
        public T Update(T model);
        public int Count();
    }
}
