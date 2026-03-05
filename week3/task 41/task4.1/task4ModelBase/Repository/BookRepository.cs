using task4ModelBase.Database.DbManager;
using task4ModelBase.Models;

namespace task4ModelBase.Repository
{
    public class BookRepository<T> : Repository<T> where T : Book
    {
        public BookRepository(DbManager<T> dBManager) : base(dBManager)
        {
            base.DbManager = dBManager;
        }
    }
}
