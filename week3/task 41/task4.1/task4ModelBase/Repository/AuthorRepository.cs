using task4ModelBase.Models;
using task4ModelBase.Database;

namespace task4ModelBase.Repository
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(DatabaseCore databaseCore) : base(databaseCore.Authors)
        {
            base.DbSet = databaseCore.Authors;
        }
    }
}
