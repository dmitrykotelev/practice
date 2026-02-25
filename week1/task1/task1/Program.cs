namespace kalk
{
    internal class Program
    {
        static List<string> operations = ["+", "-", "*", "/",];

        static int GetNum()
        {
            int num;

            if (int.TryParse(Console.ReadLine(), out num))
            {
                return num;
            }
            else
            {
                Console.WriteLine("Eror. Type a number");
                return GetNum();
            }
        }
        static string GetOperation()
        {
            string? operation = Console.ReadLine();

            if (operations.Contains(operation))
                return operation;

            else
            {
                Console.WriteLine("Wront operation, type a proper operation");
                return GetOperation();
            }
        }

        static void MainCycle()
        {

            Console.WriteLine("Type first number");
            int num1 = GetNum();
            Console.WriteLine("Type operation");
            string operation = GetOperation();
            Console.WriteLine("Type second number");
            int num2 = GetNum();

            Calc(num1, num2, operation);
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
            int UserChoise = 1;
            while (true)
            {
                Console.WriteLine("Hello! \n Type what you want to do \n 1 - Use calculator \n 2 - Exit");

                if (!int.TryParse(Console.ReadLine(), out UserChoise))
                {
                    Console.WriteLine("Error Reading, try again");
                    continue;
                }

                if (UserChoise == 1)
                    MainCycle();
                if (UserChoise == 2)
                    return;
            }
        }
    }
}