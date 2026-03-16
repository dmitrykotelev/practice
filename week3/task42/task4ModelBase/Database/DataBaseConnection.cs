using Microsoft.EntityFrameworkCore;
using task4ModelBase.Database.DbManager;
using task4ModelBase.Models;


namespace task4ModelBase.Database
{
    public class DataBaseConnection : DbContext
    {
        public DbSet<Author> Authors { get ; set; }
        public DbSet<Book> Books { get ; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ABOBA\MSSQLSERVER01;Database=task4;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}