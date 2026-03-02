namespace task4ModelBase.Interfaces

{
    public interface IRepository<T> where T : IModel
    {
        public bool Add(T model);
        public T GetById(int id);
        public List<T> GetAll();
        public bool Delete(int id);
        public bool Update(T model);
    }
}
