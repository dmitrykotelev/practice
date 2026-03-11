using System.Reflection;
using task4ModelBase.Database;
using task4ModelBase.Database.DbManager;
using task4ModelBase.Interfaces;

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
            return StatusCheck(responce);
        }
        public virtual T GetById(int id)
        {
            var responce = DbSet.GetById(id);
            return StatusCheck(responce);
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
            return StatusCheck(responce);
        }
        public T Update(T model)
        {
            var responce = DbSet.Update(model);
            return StatusCheck(responce);
        }
        private T StatusCheck(DbResponce<T> responce)
        {
            if (responce.Status == ResponceStatus.Success)
                return responce.Data;

            return null;
        }
    }
}
