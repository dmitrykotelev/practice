namespace task2
{
    internal class Program
    {
        static void SyncProc(string _data)
        {
            Random _time = new Random();
            int t = _time.Next(5000, 10000);
            Thread.Sleep(t);
            Console.WriteLine($"Sync Task done, data - {_data} in {t/1000} seconds");
            return;
        }
        async static Task AsyncProc(string _data)
        {
            Random _time = new Random();
            int t = _time.Next(5000,10000);
            await Task.Delay(t);
            Console.WriteLine($"Async Task done, data - {_data} in {t/1000} seconds");
        }
        async static Task Main(string[] args)
        {
            string file1 = "data1", file2 = "data2", file3 = "data3";
            AsyncProc(file1);
            AsyncProc(file2);
            AsyncProc(file3);
            SyncProc(file1);
            SyncProc(file2);
            SyncProc(file3);
            Console.ReadLine(); 
        }
    }
}
