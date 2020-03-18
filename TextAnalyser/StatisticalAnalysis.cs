using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyser
{
    class StatisticalAnalysis
    {
        private Dictionary<string, int> textDict;
        public StatisticalAnalysis(Iterator iter)
        {
            textDict = new Dictionary<string, int>();
            while (iter.HasNext())
            {
                string element = iter.MoveNext();
                if (textDict.ContainsKey(element))
                {
                    ++textDict[element];
                }
                else
                {
                    textDict.Add(element,1);
                }
            }
        }
        public int DictionarySize() => textDict.Count;
        public int Size() => textDict.Values.Sum();
        public int CountOf(params string[] elements)
        {
            int counter = 0;
            foreach (var element in elements)
            {
                if ( textDict.TryGetValue(element, out int val)) counter += val;
            }
            return counter;
        }
        public ISet<string> OccurMoreThan(int n)
        {
            return textDict.Where(kvp => kvp.Value > n).Select(kvp => kvp.Key).ToHashSet();
        }

    }
}