using System;
using System.Collections.Generic;
using System.Text;

namespace task_3
{
    public class MenuFunctions
    {
        public MenuEnum GetUserPick()
        {
            Console.WriteLine($"Choose what to do\n" +
                    $"{MenuEnum.Add} - {MenuEnum.Add}\n" +
                    $"{MenuEnum.GetAll} - {MenuEnum.GetAll}\n" +
                    $"{MenuEnum.Delete} -  {MenuEnum.Delete} \n" +
                    $"{MenuEnum.Update} -  {MenuEnum.Update} \n" +
                    $"{MenuEnum.Exit} -  {MenuEnum.Exit}\n");
            if (int.TryParse(Console.ReadLine(), out int UserPick))
            {
                
                if(Enum.IsDefined((MenuEnum)UserPick))
                    return (MenuEnum)UserPick;
                else
                {
                    Console.WriteLine("Wrong pick, try again");
                    return this.GetUserPick();
                }
            }
            else
            {
                Console.WriteLine("Eror type a number");
                return this.GetUserPick();
            }
        }

        public Tasks CreateObj()
        {
            Console.WriteLine("Type Name for a task");
            string name = GetString();

            Console.WriteLine("Type description for a task");
            string desc = GetString();

            return new Tasks(name, desc);
        }

        public int GetId()
        {
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
                return id;
            else
                return GetId();
        }

        public void PrintTask(Tasks task)
        {
            Console.WriteLine($"Id - {task.Id}\n" +
                $"Title - {task.Title}\n" +
                $"Description - {task.Description}\n" +
                $"Status - {task.IsCompleted}\n" +
                $"Creation Time - {task.CreatedAt.ToString()}\n");
        }
        private string GetString()
        {
            string str = Console.ReadLine();
            while (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Wrong string!");
                str = Console.ReadLine();
            }
            return str;
        }
    }
}
