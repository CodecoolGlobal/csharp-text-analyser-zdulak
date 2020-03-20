using System;
using static System.Math;
using System.Collections.Generic;
namespace TextAnalyser
{
    static class View
    {
        public static void Print<TK,TV> (IReadOnlyDictionary<TK,TV> dict) 
        {
            foreach (var pair in dict)
            {
                Console.Write($"[ {pair.Key} -> {pair.Value}] ");
            } 
            Console.WriteLine();
        }
        public static void Print<T> (ISet<T> elements)
        {
             Console.Write("[");
            int i = 0;
            foreach (var element in elements)
            {
                if (i > 0) Console.Write(", ");
                Console.Write(element);
                ++i;
            }
            Console.WriteLine("]");
        }
        // Alternative way to prepare and print dictionary
        // public static void Print<TK,TV> (IReadOnlyDictionary<TK,TV> dict, int size) 
        // {
        //     foreach (var pair in dict)
        //     {
        //         Console.Write($"[ {((dynamic)pair.Key).ToUpper()} -> " + 
        //             $"{Round((dynamic)pair.Value*100.0/size, 2)}] ");
        //     } 
        //     Console.WriteLine();
        // }

    }
}