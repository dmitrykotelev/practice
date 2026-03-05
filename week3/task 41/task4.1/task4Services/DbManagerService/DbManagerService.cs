using task4ModelBase.Database.DbManager;
using task4ModelBase.Database;
using task4ModelBase.Interfaces;

namespace task4Services.DbManager
{
    public class DbManagerService<T> where T : class
    {
        private DatabaseCore database;
        DbManagerService(DatabaseCore db)
        {
            database = db;
        }
        public DbManager<T> GetManager()
        {
            return new DbManager<T>(database);
        }
    }
}
