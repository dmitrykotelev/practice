using task4ModelBase.Database;
using task4ModelBase.Models;

namespace task4ModelBase.Repository
{
    public class BookRepository : Repository<Book>
    {

        public BookRepository(DataBaseConnection databaseCore) : base(databaseCore.Books) { }
    }
}