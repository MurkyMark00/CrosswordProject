using System;
using System.Collections.Generic;

namespace CrosswordProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Why I cast the object is explained in CreatePuzzle.cs
            char[,] puzzle = (char[,])CreatePuzzle.Create();

            if (puzzle != null)
            {
                List<WordInfo> output = Crossword.DoPuzzle(puzzle);
                foreach (var item in output)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("Not a valid puzzle. Please try again!");
            
            Console.ReadLine();
        }
    }
}
