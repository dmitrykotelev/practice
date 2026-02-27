using Azure;

namespace task_3
{
    public class Program
    {
        static void Main()
        {
            Connection connection = new Connection();
            Repository repository = new Repository(connection);
            MenuFunctions menuFunctions = new MenuFunctions();
            int id;
            while (true)
            {
                switch (menuFunctions.UserPick())
                {
                    case MenuEnum.Add:
                        {
                            repository.Add(menuFunctions.CreateObj());
                            break;
                        }
                    case MenuEnum.GetAll:
                        {
                            List<Tasks> tasks = repository.GetAll();
                            foreach (Tasks task in tasks)
                                menuFunctions.PrintTask(task);
                            break;
                        }
                    case MenuEnum.Delete:
                        {
                            Console.WriteLine("Type id of object to delete");

                            id = menuFunctions.GetId();
                            repository.Delete(id);
                            break;
                        }
                    case MenuEnum.Update:
                        {
                            Console.WriteLine("Type id of object to change completion status");
                            id = menuFunctions.GetId();
                            repository.Update(id);
                            break;
                        }
                    case MenuEnum.Exit:
                        {
                            return;
                        }
                }
            }


        }

   

    }
}
