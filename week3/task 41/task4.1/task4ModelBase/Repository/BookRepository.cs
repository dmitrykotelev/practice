using task4ModelBase.Database;
using task4ModelBase.Models;

namespace task4ModelBase.Repository
{
    public class BookRepository : Repository<Book>
    {

        public BookRepository(DatabaseCore databaseCore) : base(databaseCore.Books)
        {
            base.DbSet = databaseCore.Books;
        }
    }
}
