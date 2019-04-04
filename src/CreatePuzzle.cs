using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace CrosswordProject
{

    // This class is used to create the digital crossword puzzle entered by the user from the console.
    class CreatePuzzle
    {

        // I used object here instead of a char[,], because there were instances that I wanted to return null
        // I couldn't find a nullable char[,], so I used object instead. Let me know if there is anything better!
        public static object Create()
        {
            Console.WriteLine("Press enter when finished. Enter - to go back.");
            List<string> rows = new List<string>(); // Lines entered by the user.
            int rowNumber = 1;
            int rowLength = 0;

            while (true)
            {
                Console.Write($"\nRow {rowNumber} : ");
                string input = Console.ReadLine();

                // If user just started, setting the row length that has to be the same with other rows.
                // Since I need a rectangle matrix to properly find words.
                if (rowNumber == 1 && input.All(p => char.IsLetter(p)) && !String.IsNullOrEmpty(input))
                {
                    rowLength = input.Length;
                    rows.Add(input.Replace(" ", String.Empty));
                }
                // Other valid row entries go here.
                else if (rowNumber > 1 && input.All(p => char.IsLetter(p))
                 && !String.IsNullOrEmpty(input) && rowLength == input.Length)
                {
                    rows.Add(input.Replace(" ", String.Empty));
                }
                // Going back.
                else if (rowNumber > 1 && input == "-")
                {
                    rowNumber--;
                    rows.RemoveAt(rows.Count - 1);
                    continue;
                }
                // If the entry is not valid, it starts creating the char[,].
                else
                {
                    Console.WriteLine("Processing...");
                    break;
                }
                ++rowNumber;
            }
            // This is the instance where I want to return a null object.
            if (rows.Count == 0) return null;

            char[,] puzzle = new char[rows.Count, rowLength];
            // Converting the List<string> to a char[,]. I feel like this is not the best method.
            for (int i = 0; i < rows.Count; ++i)
            {
                for (int j = 0; j < rowLength; ++j)
                {
                    puzzle[i, j] = rows[i][j];
                }
            }
            return puzzle;
        }
    }
}