using Microsoft.EntityFrameworkCore;
using task4ModelBase.Database;
using task4ModelBase.Interfaces;

namespace task4ModelBase.Repository
{
    abstract public class Repository<T>: IRepository<T> where T : class, IModel
    {
        protected DataBaseConnection Context;
        protected DbSet<T> DbSet;

        protected Repository(DataBaseConnection context)
        {
            Context = context;
        }

        public T Add(T model)
        {
            var response = DbSet.Add(model);

            if (Save())
            return (T)response.Entity;

            return null;
        }

        public virtual T GetById(int id)
        {
            var response = DbSet.Find(id);
            return response;
        }

        public IEnumerable<T> GetAll()
        {
            var response = DbSet.ToList();
            return response;
        }

        public virtual T Delete(int id)
        {
            T model = GetById(id);
            var response = DbSet.Remove(model);

            if (Save())
                return (T)response.Entity;

            return null;
        }

        public T Update(T model)
        {
            var data = DbSet.Local.FirstOrDefault(x => x.Id == model.Id);
            DbSet.Entry(data).CurrentValues.SetValues(model);


            if (Save())
                return GetById(data.Id);

            return null;
        }

        public int Count()
        {
            return DbSet.Count(); 
        }

        public bool Save()
        {
            var status = Context.SaveChanges();
            if (status != 0)
                return true;

            return false;
        }
    }
}