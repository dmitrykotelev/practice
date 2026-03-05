using task4ModelBase.Interfaces;
using task4ModelBase.Models;
using task4ModelBase.Database;
using task4ModelBase.Database.DbManager;

namespace task4ModelBase.Repository
{
    public class AuthorRepository<T> : Repository<T> where T : Author
    {
        public AuthorRepository(DbManager<T> dBManager) : base(dBManager)
        {
            base.DbManager = dBManager;
        }
    }
}
