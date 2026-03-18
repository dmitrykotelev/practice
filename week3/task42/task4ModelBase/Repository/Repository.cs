using Microsoft.EntityFrameworkCore;
using task4ModelBase.Database;
using task4ModelBase.Interfaces;

namespace task4ModelBase.Repository
{
    abstract public class Repository<T>: IRepository<T> where T : class, IModel
    {
        private readonly DataBaseConnection _context;
        private readonly DbSet<T> _dbSet;

        protected Repository(DataBaseConnection context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T Add(T model)
        {
            var response = _dbSet.Add(model);

            if (Save())
            return (T)response.Entity;

            return null;
        }

        public virtual T GetById(int id)
        {
            var response = _dbSet.Find(id);
            return response;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var response = _dbSet.ToList();
            return response;
        }

        public virtual T Delete(int id)
        {
            T model = GetById(id);
            var response = _dbSet.Remove(model);

            if (Save())
                return (T)response.Entity;

            return null;
        }

        public virtual T Update(T model)
        {
            var data = _dbSet.Local.FirstOrDefault(x => x.Id == model.Id);
            _dbSet.Entry(data).CurrentValues.SetValues(model);


            if (Save())
                return GetById(data.Id);

            return null;
        }

        public int Count()
        {
            return _dbSet.Count(); 
        }

        private bool Save()
        {
            var status = _context.SaveChanges();
            if (status != 0)
                return true;

            return false;
        }
    }
}