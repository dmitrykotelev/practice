namespace task2
{
    internal class Program
    {
        const int T = 3000;
        static void ProcessData(string dataName)
        {
            Thread.Sleep(T);
            Console.WriteLine($"Sync Task done, data - {dataName} in {T/1000} seconds");
            return;
        }
        async static Task ProcessDataAsync(string dataName)
        {
            await Task.Delay(T);
            Console.WriteLine($"Async Task done, data - {dataName} in {T/1000} seconds");
        }
        async static Task Main(string[] args)
        {
            string file1 = "data1", file2 = "data2", file3 = "data3";
            await ProcessDataAsync(file1);
            await ProcessDataAsync(file2);
            await ProcessDataAsync(file3);
            ProcessData(file1);
            ProcessData(file2);
            ProcessData(file3);
            Console.ReadLine(); 
        }
    }
}
