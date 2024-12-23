namespace AdventDay4;

using System;

class Program
{
    static void Main(string[] args)
    {
        char[,] grid = {
            { 'X', 'M', 'A', 'S' },
            { 'M', 'X', 'A', 'X' },
            { 'A', 'M', 'S', 'A' },
            { 'S', 'A', 'M', 'X' }
        };

        string word = "XMAS";
        FindWordInGrid(grid, word);
    }

    static void FindWordInGrid(char[,] grid, string word)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        int wordLength = word.Length;

        // All 8 possible directions: right, left, down, up, diagonals
        int[] rowDirections = { 0, 0, 1, -1, 1, 1, -1, -1 };
        int[] colDirections = { 1, -1, 0, 0, 1, -1, 1, -1 };

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row, col] == word[0]) // Check starting character
                {
                    for (int direction = 0; direction < 8; direction++)
                    {
                        int r = row, c = col;
                        int k;

                        // Check if the word matches in this direction
                        for (k = 0; k < wordLength; k++)
                        {
                            if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r, c] != word[k])
                                break;

                            // Move in the direction
                            r += rowDirections[direction];
                            c += colDirections[direction];
                        }

                        if (k == wordLength) // If full word is found
                        {
                            Console.WriteLine($"Found \"{word}\" starting at ({row}, {col}) in direction ({rowDirections[direction]}, {colDirections[direction]})");
                        }
                    }
                }
            }
        }
    }
}
