using task4ModelBase.Database.DbManager;
using task4ModelBase.Models;

namespace task4ModelBase.Database
{
    public class DataBaseConnection
    {
        public readonly MyDbSet<Author> Authors;
        public readonly MyDbSet<Book> Books;

        public DataBaseConnection()
        {
            Authors = new MyDbSet<Author>();
            Books = new MyDbSet<Book>();
        }
    }
}