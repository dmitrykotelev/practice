using Microsoft.EntityFrameworkCore;
using task4ModelBase.Database.DbManager;
using task4ModelBase.Models;


namespace task4ModelBase.Database
{
    public class DataBaseConnection : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ABOBA\MSSQLSERVER01;Database=task4;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddAuthors(modelBuilder);
            AddBooks(modelBuilder);
        }

        private void AddAuthors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "William Shakespeare", DateOfBirth = new DateTime(1564, 4, 26) },
                new Author { Id = 2, Name = "George Orwell", DateOfBirth = new DateTime(1903, 6, 25) },
                new Author { Id = 3, Name = "Jane Austen", DateOfBirth = new DateTime(1775, 12, 16) },
                new Author { Id = 4, Name = "Ernest Hemingway", DateOfBirth = new DateTime(1899, 7, 21) },
                new Author { Id = 5, Name = "Stephen King", DateOfBirth = new DateTime(1947, 9, 21) },
                new Author { Id = 6, Name = "Charles Dickens", DateOfBirth = new DateTime(1812, 2, 7) },
                new Author { Id = 7, Name = "Agatha Christie", DateOfBirth = new DateTime(1890, 9, 15) },
                new Author { Id = 8, Name = "J.R.R. Tolkien", DateOfBirth = new DateTime(1892, 1, 3) },
                new Author { Id = 9, Name = "Mark Twain", DateOfBirth = new DateTime(1835, 11, 30) },
                new Author { Id = 10, Name = "Virginia Woolf", DateOfBirth = new DateTime(1882, 1, 25) }
            );
        }

        private void AddBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Hamlet", PublishedYear = new DateTime(1603, 1, 1), AuthorId = 1 },
                new Book { Id = 2, Title = "Romeo and Juliet", PublishedYear = new DateTime(1597, 1, 1), AuthorId = 1 },
                new Book { Id = 3, Title = "1984", PublishedYear = new DateTime(1949, 6, 8), AuthorId = 2 },
                new Book { Id = 4, Title = "Animal Farm", PublishedYear = new DateTime(1945, 8, 17), AuthorId = 2 },
                new Book { Id = 5, Title = "Pride and Prejudice", PublishedYear = new DateTime(1813, 1, 28), AuthorId = 3 },
                new Book { Id = 6, Title = "The Old Man and the Sea", PublishedYear = new DateTime(1952, 9, 1), AuthorId = 4 },
                new Book { Id = 7, Title = "The Shining", PublishedYear = new DateTime(1977, 1, 28), AuthorId = 5 },
                new Book { Id = 8, Title = "It", PublishedYear = new DateTime(1986, 9, 15), AuthorId = 5 },
                new Book { Id = 9, Title = "The Hobbit", PublishedYear = new DateTime(1937, 9, 21), AuthorId = 8 },
                new Book { Id = 10, Title = "The Lord of the Rings", PublishedYear = new DateTime(1954, 7, 29), AuthorId = 8 },
                new Book { Id = 11, Title = "Murder on the Orient Express", PublishedYear = new DateTime(1934, 1, 1), AuthorId = 7 }
            );
        }

    }
}