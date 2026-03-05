using task4ModelBase.Models;

namespace task4ModelBase.Database
{
    public class DatabaseCore
    {
        private List<Author> Authors = new List<Author>();
        private List<Book> Books = new List<Book>();

        public DatabaseCore() { }
        public bool AddAuthor(Author author)
        {
            Authors.Add(author);
            return true;
        }
        public bool RemoveAuthor(int id)
        {
            foreach (Author author in Authors)
                if (author.GetId() == id)
                {
                    Authors.Remove(author);
                    return true;
                }
            return false;
        }
        public Author GetAuthor(int id)
        {
            foreach (Author author in Authors)
            {
                if (author.GetId() == id) return author;
            }

            return null;
        }
        public List<Author> GetAllAuthors()
        {
            return new List<Author>(Authors);
        }
        public bool UpdateAuthor(Author author)
        {
            if (Authors.Contains(author))
            {
                for (int i = 0; i < Authors.Count; i++)
                {
                    if (!Authors[i].Equals(author))
                    {
                        Authors.Insert(i, author);
                        return true;
                    }
                }
            }
            return false;

        }


        public bool AddBook(Book book)
        {
            Books.Add(book);
            return true;
        }
        public bool RemoveBook(int id)
        {
            foreach (Book book in Books)
                if (book.GetId() == id)
                {
                    Books.Remove(book);
                    return true;
                }
            return false;
        }
        public List<Book> GetAllBooks()
        {
            return new List<Book>(Books);
        }
        public Book GetBook(int id)
        {
            foreach (Book book in Books)
            {
                if (book.GetId() == id) return book;
            }
            return null;
        }
        public bool UpdateBook(Book book)
        {
            if (Books.Contains(book))
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    if (!Books[i].Equals(book))
                    {
                        Books.Insert(i, book);
                        return true;
                    }
                }
            }
            return false;

        }

    }
}
