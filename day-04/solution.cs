using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day04
{
    internal static string Solution(string[] args)
    {
        char[,] matrix = Helpers.GetMemoryFile("../../../day-04/input.txt");
        //var targetWord = "XMAS";
        //var result = Helpers.FindWordInMatrix(matrix, targetWord);
        var result = Helpers.FindXWordInMatrix(matrix);

        return string.Format("Solution for Day 04: {0} total.", result);
    }

    private class Helpers
    {
        internal static char[,] GetMemoryFile(string filePath)
        {
            // read in entire file as string
            string fileContents = System.IO.File.ReadAllText(filePath);

            // Determine the dimensions of the matrix
            string[] lines = fileContents.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = lines.Length;
            int cols = lines[0].Length;

            char[,] matrix = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = lines[r][c];
                }
            }

            return matrix;
        }

        // Ceres Search
        internal static int FindXWordInMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int foundCount = 0;
            // this routine is specific to the word "MAS"; it expects the letter 'A' to be in the center
            const string word = "MAS";

            Console.WriteLine($"Searching for '{word}' in the matrix:");

            // Iterate through each cell in the grid
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // If the current cell is 'A', it could be the center of an 'X' pattern
                    if (matrix[r, c] == 'A')
                    {
                        // Check for the 'M' and 'S' in the 'X' shape
                        // This assumes a 3x3 pattern centered on 'A'
                        // Adjust indices based on the specific 'X' pattern required by the puzzle

                        // capture diagonals
                        // Top-left, Bottom-right
                        string diagonal1 = (r > 0 && c > 0) ? matrix[r - 1, c - 1].ToString() : "";
                        diagonal1 += matrix[r, c].ToString();
                        diagonal1 += (r < rows - 1 && c < cols - 1) ? matrix[r + 1, c + 1].ToString() : "";

                        // Top-right, Bottom-left
                        string diagonal2 = (r > 0 && c < cols - 1) ? matrix[r - 1, c + 1].ToString() : "";
                        diagonal2 += matrix[r, c].ToString();
                        diagonal2 += (r < rows - 1 && c > 0) ? matrix[r + 1, c - 1].ToString() : "";

                        // check for existence of the word in both diagonals
                        // Note: This checks both directions (e.g., "MAS" and "SAM")
                        if (diagonal1.Equals(word) || Reverse(diagonal1).Equals(word))
                        {
                            if (diagonal2.Equals(word) || Reverse(diagonal2).Equals(word))
                            {
                                foundCount++;
                                Console.WriteLine($"  Found '{diagonal1}' & '{diagonal2}' centered at ({r}, {c})");
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Total occurrences of '{word}': {foundCount}\n");
            return foundCount;
        }
        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        // Define directions for searching (8 directions: horizontal, vertical, diagonal)
        private static readonly int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        private static readonly int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
        // Depth-First Search (DFS) approach
        internal static int FindWordInMatrix(char[,] matrix, string word)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int wordLength = word.Length;
            int foundCount = 0;

            Console.WriteLine($"Searching for '{word}' in the matrix:");

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // Check all 8 directions from the current cell
                    for (int dir = 0; dir < 8; dir++)
                    {
                        int currentRow = r;
                        int currentCol = c;
                        int k; // Index for the word

                        // Check if the first character matches
                        if (matrix[currentRow, currentCol] != word[0])
                        {
                            continue;
                        }

                        // Traverse in the current direction
                        for (k = 1; k < wordLength; k++)
                        {
                            currentRow += dx[dir];
                            currentCol += dy[dir];

                            // Check bounds and character match
                            if (currentRow < 0 || currentRow >= rows ||
                                currentCol < 0 || currentCol >= cols ||
                                matrix[currentRow, currentCol] != word[k])
                            {
                                break; // Mismatch or out of bounds
                            }
                        }

                        // If the entire word is found
                        if (k == wordLength)
                        {
                            foundCount++;
                            Console.WriteLine($"  Found '{word}' starting at ({r}, {c}) in direction {dir}");
                        }
                    }
                }
            }

            Console.WriteLine($"Total occurrences of '{word}': {foundCount}\n");
            return foundCount;
        }
    }
}
