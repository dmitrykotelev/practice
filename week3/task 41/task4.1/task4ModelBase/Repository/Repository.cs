using task4ModelBase.Database.DbManager;
using task4ModelBase.Interfaces;
using task4ModelBase.Database;

namespace task4ModelBase.Repository
{
    abstract public class Repository<T> where T : class
    {
        protected DbManager<T> DbManager;

        protected Repository(DbManager<T> dBManager)
        {
            DbManager = dBManager;
        }

        public bool Add(T model)
        {
            var responce = DbManager.Add((T)model);
            if (responce.Status == ResponceStatus.Success)
                return true;
            else return false;
        }
        public virtual T GetById(int id)
        {
            var responce = DbManager.GetById(id);
            if (responce.Status == ResponceStatus.Success)
                return responce.Data;
            return default(T);
        }
        public List<T> GetAll()
        {
            var responce = DbManager.GetAll();
            if (responce.Status == ResponceStatus.Success)
                return responce.Data;
            return null;
        }
        public virtual bool Delete(int id)
        {
            var responce = DbManager.Delete(id);
            if (responce.Status == ResponceStatus.Success)
                return true;
            return false;
        }
        public bool Update(T model)
        {
            var responce = DbManager.Update(model);
            if (responce.Status == ResponceStatus.Success)
                return true;
            return false;
        }
    }
}
