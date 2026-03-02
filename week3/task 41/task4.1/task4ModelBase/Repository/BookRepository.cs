using System.Reflection;
using task4ModelBase.Database;
using task4ModelBase.Interfaces;
using task4ModelBase.Models;

namespace task4ModelBase.Repository
{
    public class BookRepository<T> : Repository<T>, IRepository<T> where T : Book
    {
        public BookRepository(DatabaseCore database) : base(database)
        {
            base.Database = database;
        }

        override public bool Add(T model)
        {
            if (Database.AddBook(model).Status == ResponceStatus.SuccessAdd)
                return true;
            return false;
        }
        override public T GetById(int id)
        {
            DbResponce<Book> responce = Database.GetBook(id);
            if (responce.Status == ResponceStatus.SuccessReturn)
                return (T)responce.Model;
            return null;
        }
        override public List<T> GetAll()
        {
            DbResponce<Book> responce = Database.GetAllBooks();

            if (responce.Status == ResponceStatus.SuccessReturn)
                return responce.Models.Cast<T>().ToList();

            return null;
        }
        override public bool Delete(int id)
        {
            if (Database.RemoveBook(id).Status == ResponceStatus.SuccessDelete)
                return true;
            return false;
        }
        override public bool Update(T model)
        {
            if (Database.UpdateBook(model).Status == ResponceStatus.SuccessUpdate)
                return true;
            return false;
        }

    }
}
