using task4ModelBase.Interfaces;
using task4ModelBase.Database;

namespace task4ModelBase.Repository
{
    // переделать под джненерик, упростить, вынести всю реализацию сюда из конкретных репозиториев
    abstract public class Repository<T> : IRepository<T> where T : IModel
    {
        protected DatabaseCore Database;
        public Repository(DatabaseCore database)
        {
            Database = database;
        }
        abstract public bool Add(T model);

        abstract public T GetById(int id);
        abstract public List<T> GetAll();
        abstract public bool Delete(int id);
        abstract public bool Update(T model);
    }
}
