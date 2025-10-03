using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day04
{
    // Define directions for searching (8 directions: horizontal, vertical, diagonal)
    private static readonly int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
    private static readonly int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

    internal static string Solution(string[] args)
    {
        char[,] matrix = Helpers.GetMemoryFile("../../../day-04/input.txt");
        var targetWord = "XMAS";
        var result = Helpers.FindWordInMatrix(matrix, targetWord);

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
