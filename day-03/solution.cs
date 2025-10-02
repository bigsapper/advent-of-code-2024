using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day03
{
    internal static string Solution(string[] args)
    {
        var mem = Helpers.GetMemoryFile("../../../day-03/input.txt");
        var matches = Helpers.ParseMultiplicationOps(mem);
        var total = Helpers.GetMultiplicationTotal(matches);

        return string.Format("Solution for Day 03: {0} total of multiplication operations.", total);
    }

    private class Helpers
    {
        internal static string GetMemoryFile(string filePath)
        {
            // read in entire file as string
            string fileContents = System.IO.File.ReadAllText(filePath);

            return fileContents;

        }

        internal static MatchCollection ParseMultiplicationOps(string mem)
        {
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

            MatchCollection matches = Regex.Matches(mem, pattern);

            Console.WriteLine("Found matches:");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Full match: {match.Value}");
            }
            return matches;
        }

        internal static int GetMultiplicationTotal(MatchCollection matches)
        {
            int total = 0;
            foreach (Match match in matches)
            {
                // Extract the two numbers from the match
                int num1 = int.Parse(match.Groups[1].Value);
                int num2 = int.Parse(match.Groups[2].Value);

                // Perform the multiplication
                int result = num1 * num2;
                total += result;
            }

            return total;
        }
    }
}
