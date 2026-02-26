namespace task_3
{
    public class Program
    {
        enum Menu
        {
            None = 0,
            Add = 1,
            GetAll = 2,
            Delete = 3,
            Update = 4,
            Exit = 5,
        }

        static int UserPick()
        {
            Console.WriteLine($"Choose what to do\n" +
                    $"{Menu.Add} - 1\n" +
                    $"{Menu.GetAll} - 2\n" +
                    $"{Menu.Delete} - 3\n" +
                    $"{Menu.Update} - 4\n" +
                    $"{Menu.Exit} - 5\n");
            if (int.TryParse(Console.ReadLine(), out int i))
            {
                return i;
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
            Console.WriteLine("Type description for a task");
            string desc = Console.ReadLine();
            return new Tasks(name, desc);
        }

        static void PrintTask(Tasks task)
        {
            Console.WriteLine($"Id - {task.Id}\n" +
                $"Name - {task.Name}\n" +
                $"Description - {task.Description}\n" +
                $"Status - {task.IsCompleted}\n" +
                $"Creation Time - {task.CreatedAt.ToString()}\n");
        }

        static void Main()
        {
            Connection connection = new Connection();
            Repository repository = new Repository(connection);
            Menu userpick = 0;
            int id;
            while (true)
            {
                switch (UserPick())
                {
                    case 1:
                        {
                            repository.Add(CreateObj());
                            break;
                        }
                    case 2:
                        {
                            List<Tasks> tasks = repository.GetAll();
                            foreach (Tasks task in tasks)
                                PrintTask(task);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Type id of object to delete");
                            
                            int.TryParse(Console.ReadLine(), out id);
                            repository.Delete(id);
                            break;
                        }
                    case 4: 
                        {
                            Console.WriteLine("Type id of object to change completion status");
                            int.TryParse(Console.ReadLine(), out id);
                            repository.Update(id);
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                }
            }


        }
    }
}
