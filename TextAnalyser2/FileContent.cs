using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace TextAnalyser
{

    interface IterableText
    {
        IEnumerable<string> CharIterator();
        IEnumerable<string> WordIterator();
    }

    class FileContent: IterableText
    {
        public string FileName {get; }
        public FileContent (string fileName) => FileName = fileName;
        public IEnumerable<string> CharIterator()
        {
            StreamReader textReader = new StreamReader(FileName);
            int charInt;
            while ((charInt = textReader.Read()) != -1)
            {
                var theChar = (char)charInt;
                if (Char.IsLetterOrDigit(theChar)) yield return theChar.ToString().ToLower();
            }
        } 
        public IEnumerable<string> WordIterator() 
        {
            StreamReader textReader = new StreamReader(FileName);
            StringBuilder word = new StringBuilder();
            int charInt;
            while ((charInt = textReader.Read()) != -1)
            {
                var theChar = (char)charInt;
                if (Char.IsLetterOrDigit(theChar)) 
                {
                    word.Append(theChar.ToString().ToLower());
                }
                else if (word.Length != 0)
                {
                    yield return word.ToString();
                    word.Clear();
                }
            }
            if (word.Length != 0)  yield return word.ToString();
        }
    }
}