using task4ModelBase.Models;
using task4ModelBase.Database;


namespace task4ModelBase.Database
{
    //вынести все к хуям в менеджер, база максимально тупая
    public class DatabaseCore
    {
        private List<Author> Authors = new List<Author>();
        private List<Book> Books = new List<Book>();

        public DatabaseCore() { }
        public DbResponce<Author> AddAuthor(Author author)
        {
            Authors.Add(author);
            return new DbResponce<Author>(ResponceStatus.SuccessAdd);
        }
        public DbResponce<Author> RemoveAuthor(int id)
        {
            foreach (Author author in Authors)
                if (author.GetId() == id)
                {
                    Authors.Remove(author);
                    return new DbResponce<Author>(ResponceStatus.SuccessDelete);
                }
            return new DbResponce<Author>(ResponceStatus.NotFound);
        }
        public DbResponce<Author> GetAuthor(int id)
        {
            foreach (Author author in Authors)
            {
                if (author.GetId() == id) return new DbResponce<Author>(ResponceStatus.SuccessReturn, author);
            }

            return new DbResponce<Author>(ResponceStatus.NotFound);
        }
        public DbResponce<Author> GetAllAuthors()
        {
            return new DbResponce<Author>(ResponceStatus.SuccessReturnList, Authors);
        }
        public DbResponce<Author> UpdateAuthor(Author author)
        {
            if (Authors.Contains(author))
            {
                for (int i = 0; i < Authors.Count; i++)
                {
                    if (!Authors[i].Equals(author))
                    {
                        Authors.Insert(i, author);
                        return new DbResponce<Author>(ResponceStatus.SuccessUpdate);
                    }
                }
            }
            else return new DbResponce<Author>(ResponceStatus.NotFound);
            return new DbResponce<Author>(ResponceStatus.Failure);

        }


        public DbResponce<Book> AddBook(Book book)
        {
            Books.Add(book);
            return new DbResponce<Book>(ResponceStatus.SuccessAdd);
        }
        public DbResponce<Book> RemoveBook(int id)
        {
            foreach (Book book in Books)
                if (book.GetId() == id)
                {
                    Books.Remove(book);
                    return new DbResponce<Book>(ResponceStatus.SuccessDelete);
                }
            return new DbResponce<Book>(ResponceStatus.NotFound);
        }
        public DbResponce<Book> GetAllBooks()
        {
            return new DbResponce<Book>(ResponceStatus.SuccessReturnList, Books);
        }
        public DbResponce<Book> GetBook(int id)
        {
            foreach (Book book in Books)
            {
                if (book.GetId() == id) return new DbResponce<Book>(ResponceStatus.SuccessReturn, book);
            }
            return new DbResponce<Book>(ResponceStatus.NotFound);
        }
        public DbResponce<Book> UpdateBook(Book book)
        {
            if (Books.Contains(book))
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    if (!Books[i].Equals(book))
                    {
                        Books.Insert(i, book);
                        return new DbResponce<Book>(ResponceStatus.SuccessUpdate);
                    }
                }
            }
            else return new DbResponce<Book>(ResponceStatus.NotFound);
            return new DbResponce<Book>(ResponceStatus.Failure);

        }

    }
}
