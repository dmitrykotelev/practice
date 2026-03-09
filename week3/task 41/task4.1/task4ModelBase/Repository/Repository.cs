using task4ModelBase.Database.DbManager;
using task4ModelBase.Interfaces;
using task4ModelBase.Database;

namespace task4ModelBase.Repository
{
    abstract public class Repository<T> where T : class , IModel
    {
        protected MyDbSet<T> DbSet;

        protected Repository(MyDbSet<T> dBManager)
        {
            DbSet = dBManager;
        }

        public T Add(T model)
        {
            var responce = DbSet.Add((T)model);
            if (responce.Status == ResponceStatus.Success)
                return responce.Data;
            else return null;
        }
        public virtual T GetById(int id)
        {
            var responce = DbSet.GetById(id);
            if (responce.Status == ResponceStatus.Success)
                return responce.Data;
            return null;
        }
        public IEnumerable<T> GetAll()
        {
            var responce = DbSet.GetAll();
            if (responce.Status == ResponceStatus.Success)
                return responce.Data;
            return null;
        }
        public virtual T Delete(int id)
        {
            var responce = DbSet.Delete(id);
            if (responce.Status == ResponceStatus.Success)
                return responce.Data;
            return null;
        }
        public T Update(T model)
        {
            var responce = DbSet.Update(model);
            if (responce.Status == ResponceStatus.Success)
                return responce.Data;
            return null;
        }
    }
}
