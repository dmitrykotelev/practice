namespace kalk
{
    internal class Program
    {
        static int num1, num2;
        static string operation;

        static void Main()
        {
            int result = 0;

            Console.WriteLine("Type first number");
            num1 = Convert.ToInt32 (Console.ReadLine());
            Console.WriteLine("Type operation");
            operation = Console.ReadLine();
            Console.WriteLine("Type second number");
            num2 = Convert.ToInt32 (Console.ReadLine());

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
                        result = num1 / num2;
                        break;
                    }
            }

            Console.WriteLine($"Result of {operation} operation is {result}");
            Console.ReadLine();
        }
    }
}
