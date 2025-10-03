using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day04
{
    internal static string Solution(string[] args)
    {
        var mem = Helpers.GetMemoryFile("../../../day-04/input.txt");

        return string.Format("Solution for Day 04: {0} total...", 0);
    }

    private class Helpers
    {
        internal static string GetMemoryFile(string filePath)
        {
            // read in entire file as string
            string fileContents = System.IO.File.ReadAllText(filePath);

            return fileContents;

        }
    }
}
