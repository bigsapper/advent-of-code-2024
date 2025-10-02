using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day03
{
    internal static string Solution(string[] args)
    {
        var lines = Helpers.GetMemoryFile("../../../day-02/input.txt");
        Helpers.boop();
        return "";
    }

    private class Helpers
    {
        internal static string GetMemoryFile(string filePath)
        {
            // read in entire file as string
            string fileContents = System.IO.File.ReadAllText(filePath);

            return fileContents;

        }

        internal static bool boop()
        {
            string text = "This is a test string with mul(1,23) and another mul(456,78) and also mul(9,1) but not mul(1234,5) or mul(1,567).";
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

            MatchCollection matches = Regex.Matches(text, pattern);

            Console.WriteLine("Found matches:");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Full match: {match.Value}");
                Console.WriteLine($"  First number: {match.Groups[1].Value}");
                Console.WriteLine($"  Second number: {match.Groups[2].Value}");
                Console.WriteLine();
            }
            return true;
        }
    }
}
