using System;
using System.Numerics;
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
            string patternMulOps = @"mul\((\d{1,3}),(\d{1,3})\)";
            string patternDoDontOps = @"do\(\)|don't\(\)";

            MatchCollection matches = Regex.Matches(mem, patternMulOps + "|" + patternDoDontOps);

            Console.WriteLine("Found matches:");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Full match: {match.Value}");
            }
            return matches;
        }

        internal static long GetMultiplicationTotal(MatchCollection matches)
        {
            long total = 0;
            bool yep = true;

            foreach (Match match in matches)
            {
                // This is a "do()" or "don't()" operation
                if (match.Value[0] == 'd')
                {
                    yep = match.Value == "do()";
                    // skip to next operation
                    continue;
                }

                if (yep)
                {
                    // Extract the two numbers from the match
                    int num1 = int.Parse(match.Groups[1].Value);
                    int num2 = int.Parse(match.Groups[2].Value);

                    // Perform the multiplication
                    long result = (long)num1 * num2;

                    total += result;
                }
            }

            return total;
        }
    }
}
