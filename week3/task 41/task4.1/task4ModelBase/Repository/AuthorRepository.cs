using task4ModelBase.Interfaces;
using task4ModelBase.Models;
using task4ModelBase.Database;

namespace task4ModelBase.Repository
{
    public class AuthorRepository<T> : Repository<T>, IRepository<T> where T : Author
    {
        public AuthorRepository(DatabaseCore database) : base(database)
        {
            base.Database = database;
        }

        override public bool Add(T model)
        {
            if (Database.AddAuthor(model).Status == ResponceStatus.SuccessAdd)
                return true;
            return false;
        }
        override public T GetById(int id)
        {
            DbResponce<Author> responce = Database.GetAuthor(id);
            if (responce.Status == ResponceStatus.SuccessReturn)
                return (T)responce.Model;
            return null;
        }
        override public List<T> GetAll()
        {
            DbResponce<Author> responce = Database.GetAllAuthors();

            if (responce.Status == ResponceStatus.SuccessReturn)
                return responce.Models.Cast<T>().ToList();

            return null;
        }
        override public bool Delete(int id)
        {
            if (Database.RemoveAuthor(id).Status == ResponceStatus.SuccessDelete)
                return true;
            return false;
        }
        override public bool Update(T model)
        {
            if (Database.UpdateAuthor(model).Status == ResponceStatus.SuccessUpdate)
                return true;
            return false;
        }

    }
}
