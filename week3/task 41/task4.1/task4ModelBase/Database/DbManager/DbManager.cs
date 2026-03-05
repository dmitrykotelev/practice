using task4ModelBase.Interfaces;
using task4ModelBase.Models;

namespace task4ModelBase.Database.DbManager
{
    public class DbManager<T> where T : class
    {
        private DatabaseCore Database;
        public DbManager() { }
        public DbManager(DatabaseCore database)
        {
            Database = database; 
        }
        public DbResponce<T> Add(T data)
        {
            if (typeof(T) == typeof(Book))
            {
                if (!Database.AddBook((Book)(object)data))
                    return new DbResponce<T>(ResponceStatus.Success);
                else
                    return new DbResponce<T>(ResponceStatus.NotFound, new Error());
            }
            if (typeof(T) == typeof(Author))
            {
                if (!Database.AddAuthor((Author)(object)data))
                    return new DbResponce<T>(ResponceStatus.Success);
                else
                    return new DbResponce<T>(ResponceStatus.NotFound, new Error());
            }
            else return new DbResponce<T>(ResponceStatus.Failure, new Error());
        }
        public DbResponce<T> GetById(int id)
        {
            T data = null;
            if (typeof(T) == typeof(Book))
            {
                data = (T)(object)Database.GetAllBooks();
                if (data != null)
                    return new DbResponce<T>(ResponceStatus.Success, data);
                else
                    return new DbResponce<T>(ResponceStatus.NotFound, new Error());
            }
            if (typeof(T) == typeof(Author))
            {
                data = (T)(object)Database.GetAllAuthors();
                if (data != null)
                    return new DbResponce<T>(ResponceStatus.Success, data);
                else
                    return new DbResponce<T>(ResponceStatus.NotFound, new Error());
            }
            return new DbResponce<T>(ResponceStatus.Failure, new Error());
        }
        public DbResponce<T> Delete(int id)
        {
            if (typeof(T) == typeof(Book))
            {
                if (!Database.RemoveBook(id))
                    return new DbResponce<T>(ResponceStatus.Success);
                else
                    return new DbResponce<T> (ResponceStatus.NotFound, new Error());
            }
            if (typeof(T) == typeof(Author))
            {
                if (!Database.RemoveAuthor(id))
                    return new DbResponce<T>(ResponceStatus.Success);
                else
                    return new DbResponce<T>(ResponceStatus.NotFound, new Error());
            }
            else return new DbResponce<T>(ResponceStatus.Failure, new Error());

        }
        public DbResponce<List<T>> GetAll()
        {
            List<T> data = new List<T>();
            if (typeof(T) == typeof(Book))
            {
                data = (List<T>)(object)Database.GetAllBooks();
                if (data != null)
                    return new DbResponce<List<T>>(ResponceStatus.Success, data);
                else 
                    return new DbResponce<List<T>> (ResponceStatus.NotFound, new Error());
            }
            if (typeof(T) == typeof(Author))
            {
                data = (List<T>)(object)Database.GetAllAuthors();
                if (data != null)
                    return new DbResponce<List<T>>(ResponceStatus.Success, data);
                else
                    return new DbResponce<List<T>>(ResponceStatus.NotFound, new Error());
            }
            return new DbResponce<List<T>>(ResponceStatus.Failure, new Error());
        }
        public DbResponce<T> Update(T data)
        {
            if (data is Author author)
            {
                if (Database.UpdateAuthor(author))
                    return new DbResponce<T>(ResponceStatus.Success);
                else return new DbResponce<T>(ResponceStatus.NotFound, new Error());
            }

            if (data is Book book)
            {
                if (Database.UpdateBook(book))
                    return new DbResponce<T>(ResponceStatus.Success);
                else return new DbResponce<T>(ResponceStatus.Failure, new Error());
            }
            return new DbResponce<T>(ResponceStatus.Failure);
        }

    }
}
