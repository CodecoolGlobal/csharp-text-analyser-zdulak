using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyser
{
    class StatisticalAnalysis
    {
        public ReadOnlyDictionary<string,int> ElementsDictionary {get; }
        public int Size {get; }
        public StatisticalAnalysis(Iterator iter)
        {
            var tempDict = new Dictionary<string, int>();
            try
            {
                while (iter.HasNext())
                {
                    string element = iter.MoveNext();
                    if (tempDict.ContainsKey(element))
                    {
                        ++tempDict[element];
                    }
                    else
                    {
                        tempDict.Add(element,1);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("The file could not be read:" + ex.Message);
            }
            ElementsDictionary = new ReadOnlyDictionary<string, int>(tempDict);
            Size = ElementsDictionary.Values.Sum();
        }
        public int DictionarySize => ElementsDictionary.Count;
        public int CountOf(params string[] elements)
        {
            elements = elements.Select(x => x.ToLower()).ToArray();
            int counter = 0;
            foreach (var element in elements)
            {
                if ( ElementsDictionary.TryGetValue(element, out int val)) counter += val;
            }
            return counter;
        }
        public ISet<string> OccurMoreThan(int n)
        {
            return new SortedSet<string>(ElementsDictionary.Where(kvp => kvp.Value > n).Select(kvp => kvp.Key));
        }

    }
}