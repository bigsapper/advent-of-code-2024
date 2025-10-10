using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day05
{
    internal static string Solution(string[] args)
    {
        char[,] matrix = Helpers.GetMemoryFile("../../../day-05/input.txt");
        int result = 0;
        return string.Format("Solution for Day 05: {0} total.", result);
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
    }
}
