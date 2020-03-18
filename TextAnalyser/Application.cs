using System;
using System.IO;

namespace TextAnalyser
{
    class Application
    {
        static void Main(string[] args)
        {
            var time = System.Diagnostics.Stopwatch.StartNew();
            foreach (var path in args)
            {
                try
                {
                    using (StreamReader fileStream = new StreamReader(path))
                    {
                        Console.WriteLine(fileStream.ReadLine());
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("The file could not be read:" + ex.Message);
                }
            }
            time.Stop();
            double elapsedTime = time.ElapsedMilliseconds/1000.0;
            Console.WriteLine($"Benchmark time: {elapsedTime} secs");
        }
    }
}
