using task4ModelBase.Database;
using task4ModelBase.Interfaces;
using task4ModelBase.Repository;
using task4ModelBase.Models;

namespace task4ModelBase
{
    public class Tester
    {
        static AuthorRepository Repo;
        static DatabaseCore DatabaseCore = new DatabaseCore();

        static void Main()
        {
            Repo = new AuthorRepository(DatabaseCore);

            Author author = new Author();
            author.Name = "Test";
            Repo.Add(author);
            var data = Repo.GetAll();
            foreach (var item in data)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }
            var rep = Repo.Delete(0);
            Console.WriteLine(rep.Name);

        }
        

    }
}
