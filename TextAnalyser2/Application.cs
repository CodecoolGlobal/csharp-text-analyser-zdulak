using System;
using static System.Math;
using System.Linq;

namespace TextAnalyser
{
    class Application
    {
        static void Main(string[] args)
        {
            var time = System.Diagnostics.Stopwatch.StartNew();
            foreach (var path in args)
            {
                var fileContent = new FileContent(path);
                var charsAnalysis = new StatisticalAnalysis(fileContent.CharIterator());
                var wordsAnalysis = new StatisticalAnalysis(fileContent.WordIterator());
                // Print results of the analysis
                Console.WriteLine($"---{path}---");
                Console.WriteLine("Char count: " + charsAnalysis.Size);
                Console.WriteLine("Word count: " + wordsAnalysis.Size);
                Console.WriteLine("Dict size: " + wordsAnalysis.DictionarySize);
                Console.Write("Most used words (>1%): "); 
                View.Print(wordsAnalysis.OccurMoreThan(wordsAnalysis.Size/100));
                Console.WriteLine("'love' count: " + wordsAnalysis.CountOf("love"));
                Console.WriteLine("'hate' count: " + wordsAnalysis.CountOf("hate"));
                Console.WriteLine("'music' count: " + wordsAnalysis.CountOf("music"));
                Console.WriteLine("vowels %: " + 
                    Round(charsAnalysis.CountOf("a","o","i","e","u")*100.0/charsAnalysis.Size, 2));
                Console.WriteLine("a:e count ratio: " + 
                    Round((double)charsAnalysis.CountOf("a")/charsAnalysis.CountOf("e"), 2));
                var charsStatistic = charsAnalysis.ElementsDictionary
                    .Select(kvp => (kvp.Key.ToUpper(), Round(kvp.Value*100.0/charsAnalysis.Size, 2)))
                    .ToDictionary(t => t.Item1, t => t.Item2);
                View.Print(charsStatistic);
            }
            time.Stop();
            double elapsedTime = time.ElapsedMilliseconds/1000.0;
            Console.WriteLine($"Benchmark time: {elapsedTime} secs");
        }
    }
}
