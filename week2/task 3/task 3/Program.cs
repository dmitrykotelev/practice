using Azure;

namespace task_3
{
    public class Program
    {
        static void Main()
        {
            Connection connection = new Connection();
            Repository repository = new Repository(connection);
            int id;
            while (true)
            {
                switch (UserPick())
                {
                    case MenuEnum.Add:
                        {
                            repository.Add(CreateObj());
                            break;
                        }
                    case MenuEnum.GetAll:
                        {
                            List<Tasks> tasks = repository.GetAll();
                            foreach (Tasks task in tasks)
                                PrintTask(task);
                            break;
                        }
                    case MenuEnum.Delete:
                        {
                            Console.WriteLine("Type id of object to delete");

                            int.TryParse(Console.ReadLine(), out id);
                            repository.Delete(id);
                            break;
                        }
                    case MenuEnum.Update:
                        {
                            Console.WriteLine("Type id of object to change completion status");
                            int.TryParse(Console.ReadLine(), out id);
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

        static MenuEnum UserPick()
        {
            Console.WriteLine($"Choose what to do\n" +
                    $"{MenuEnum.Add} - 1\n" +
                    $"{MenuEnum.GetAll} - 2\n" +
                    $"{MenuEnum.Delete} - 3\n" +
                    $"{MenuEnum.Update} - 4\n" +
                    $"{MenuEnum.Exit} - 5\n");
            if (int.TryParse(Console.ReadLine(), out int i))
            {
                var fields = typeof(MenuEnum).GetFields().Where(fi => fi.IsLiteral);
                MenuEnum[] fieldValues = fields.Select(fi => fi.GetRawConstantValue()).Cast<MenuEnum>().ToArray();
                try
                {
                    return fieldValues[i];
                }
                catch
                {
                    Console.WriteLine("Wrong pick, try again");
                    return UserPick();
                }
            }
            else
            {
                Console.WriteLine("Eror type a number");
                return UserPick();
            }
        }

        static Tasks CreateObj()
        {
            Console.WriteLine("Type Name for a task");
            string name = Console.ReadLine();
            while (name == null || name == " ")
            {
                Console.WriteLine("null is found");
                name = Console.ReadLine();
            }
            Console.WriteLine("Type description for a task");
            string desc = Console.ReadLine();
            while (desc == null || desc == " ")
            {
                Console.WriteLine("null is found");
                desc = Console.ReadLine();
            }
            return new Tasks(name, desc);
        }

        static void PrintTask(Tasks task)
        {
            Console.WriteLine($"Id - {task.Id}\n" +
                $"Title - {task.Title}\n" +
                $"Description - {task.Description}\n" +
                $"Status - {task.IsCompleted}\n" +
                $"Creation Time - {task.CreatedAt.ToString()}\n");
        }

    }
}
