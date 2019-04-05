using System;
using System.Collections.Generic;

namespace CrosswordProject
{
    public static class Crossword
    {
        // Puzzle example : 
         /*
            A S E S
            E K L K
            S B L A
            K A I N
        */
        // This method just brute forces(?) its way through the matrix to find a word.
        // If there is a better method, please let me know!
        public static List<WordInfo> DoPuzzle(char[,] puzzle)
        {
            DictionaryAccess myDictionary = new DictionaryAccess();
            List<WordInfo> correctWords = new List<WordInfo>();

            // This variable constantly changes and if its a valid word, it gets added to the correctWords List.
            List<char> tempWord = new List<char>();

            // Horizontal Check
            for (int i = 0; i < puzzle.GetLength(0); ++i)
            {
                for (int j = 0; j < puzzle.GetLength(1); ++j)
                {
                    tempWord.Clear();
                    for (int k = j; k < puzzle.GetLength(1); ++k)
                    {
                        // Check for word from puzzle[i, j] to puzzle[i, k]
                        tempWord.Add(puzzle[i,k]);
                        string tempString = new string(tempWord.ToArray());

                        // This is where it gets stored.
                        if (myDictionary.TestWord(tempString)) 
                            correctWords.Add(new WordInfo(tempString, i, k, "Vertical"));
                        
                    }
                }   
            }
            // Vertical Check
            for (int j = 0; j < puzzle.GetLength(1); j++)
            {
                for (int i = 0; i < puzzle.GetLength(0); i++)
                {
                    tempWord.Clear();
                    for (int k = i; k < puzzle.GetLength(0); k++)
                    {
                        tempWord.Add(puzzle[k,j]);
                        string tempString = new string(tempWord.ToArray());

                        if (myDictionary.TestWord(tempString))
                            correctWords.Add(new WordInfo(tempString, k, j, "Dikey"));
                    }
                }
            }
            return correctWords;
        }
    }
}