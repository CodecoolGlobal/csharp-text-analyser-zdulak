using System;
using System.IO;
using System.Text;

namespace TextAnalyser
{
    interface Iterator
    {
        bool HasNext();
        string MoveNext();
        //void Reset();

    }
    interface IterableText
    {
        Iterator CharIterator();
        Iterator WordIterator();
    }

    class FileContent: IterableText
    {
        public string FileName {get; }
        FileContent (string fileName) => FileName = fileName;
        public Iterator CharIterator() => new CharIterator(this);
        public Iterator WordIterator() => new WordIterator(this);
    }
    class CharIterator: Iterator
    {
        protected StreamReader textReader;
        public CharIterator(FileContent fileContent) => textReader = new StreamReader(fileContent.FileName);
        ~CharIterator() => textReader.Close();
        public bool HasNext()
        {
            int charInt;
            while ((charInt = textReader.Peek()) != -1)
            {
                if (Char.IsLetterOrDigit((char)charInt))
                {
                    return true;
                }
                else
                {
                    textReader.Read();
                }
            }
            return false;
        }
        public string MoveNext()
        {
            if (HasNext())
            {
                return textReader.Read().ToString().ToLower();
            }
            else
            {
                return "";
            }
        }
        // public void Reset()
        // {
        //     textReader.BaseStream.Position = 0;
        //     textReader.DiscardBufferedData();
        // }
    }
    class WordIterator: CharIterator, Iterator
    {
        public WordIterator(FileContent fileContent): base(fileContent) {}
        public new string MoveNext()
        {
            StringBuilder word = new StringBuilder();
            if (HasNext())
            {
                int charInt;
                do
                {
                    word.Append(textReader.Read().ToString().ToLower());
                    charInt = textReader.Peek();
                } while (charInt != -1 && Char.IsLetterOrDigit((char)charInt));
            }
            return word.ToString();
        }
    }
}