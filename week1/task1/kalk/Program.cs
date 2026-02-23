using System.Diagnostics;

namespace kalk
{
    internal class Program
    {
        static List<string> operations = ["+","-","*","/",];
        enum Operations
        {
            
        }

        static int GetNum()
        {
            int _num;
            try
            {
                _num = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Eror. Type a number");
                _num = GetNum();
                return _num;
            }
            return _num; 
        }
        static string GetOperation()
        {
            string? _operation;
            _operation = Console.ReadLine();

            if (operations.Contains(_operation))
                return _operation;
            else
            {
                Console.WriteLine("Wront operation, type a proper operation");
                _operation = GetOperation();
                return _operation;
            }
        }

        static void MainCycle()
        {
            int num1, num2;
            string? operation;

            Console.WriteLine("Type first number");
            num1 = GetNum();
            Console.WriteLine("Type operation");
            operation = GetOperation();
            Console.WriteLine("Type second number");
            num2 = GetNum();

            Calc(num1,num2,operation);
            return;

        }

        static bool Calc(int num1, int num2, string operation)
        {
            int result = 0;
            switch (operation)
            {
                case "+":
                    {
                        result = num1 + num2;
                        break;
                    }
                case "-":
                    {
                        result = num1 - num2;
                        break;
                    }
                case "*":
                    {
                        result = num1 * num2;
                        break;
                    }
                case "/":
                    {
                        try
                        {
                            result = num1 / num2;
                            break;
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine("Error. Dividence by 0 detected");
                            return false;
                        }
                    }
            }

            Console.WriteLine($"Result of {operation} operation is {result}");
            return true;
        }

        static void Main()
        {
            int st = 1;
            while (true)
            {
                Console.WriteLine("Hello! \n Type what you want to do \n 1 - Use calculator \n 2 - Exit");
                try
                {
                    st = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error Reading, try again");
                    st = Convert.ToInt32(Console.ReadLine());
                }
                if (st == 2)
                    return;
                MainCycle();
            }
        }
    }
}
