using task4ModelBase.Database.DbManager;
using task4ModelBase.Models;

namespace task4ModelBase.Database
{
    public class DatabaseCore
    {
        public readonly MyDbSet<Author> Authors;
        public readonly MyDbSet<Book> Books;

        public DatabaseCore()
        {
            Authors = new MyDbSet<Author>();
            Books = new MyDbSet<Book>();
        }

    }
}
