using System;
using System.IO;
using System.Collections.Generic;

namespace CrosswordProject
{
    // Using this class to output better information about the word.
    public class WordInfo
    {
        public string Word { get; set; } = "";
        public int StartingRowX { get; set; } = 0;
        public int StartingColumnY { get; set; } = 0;
        public string Direction { get; set; } = "";

        public override string ToString() 
        {
            return new string($"{Word} : Row = {StartingRowX + 1}, Column = {StartingColumnY + 1}, Direction = {Direction}");
        }

        // Constructor
        public WordInfo(string word = "", int rowX = 0, int columnY = 0, string way = "")
        {
            this.Word = word;
            // Getting the starting positions instead of the endings to make finding the word easier for the user.
            if (way == "Vertical")
            {
                this.StartingRowX =  rowX;
                this.StartingColumnY = columnY + 1 - word.Length;
            }
            else // It will be Horizontal
            {
                this.StartingRowX = rowX + 1 - word.Length;
                this.StartingColumnY = columnY;
            }
            this.Direction = way;
        }
    }

    public class DictionaryAccess
    {
        public List<string> dictionaryList = new List<string>();
        public DictionaryAccess()
        {
            // Writing the file to an array
            // Avoiding words with '
            // Also removing white spaces as most crossword puzzles dont use them.
            using (StreamReader sr = File.OpenText(@"res\20k.txt"))
            {
                while(!sr.EndOfStream)
                {
                    string tempLine = sr.ReadLine().Replace(" ", String.Empty);
                    if(!tempLine.Contains('\'')) dictionaryList.Add(tempLine);
                }
            }
        }
        public bool TestWord(string str)
        {
            // Only testing words longer than a character.
            // Because most crossword puzzles dont have letter answers.
            if (str.Length > 1)
            {
                foreach (string testStr in dictionaryList)
                {
                    if (testStr.Equals(str, StringComparison.CurrentCultureIgnoreCase))
                        return true;
                }
            }
            return false;
        }
    }
}