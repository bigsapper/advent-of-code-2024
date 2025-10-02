using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace AdventOfCode2024;

public class Day02
{
    internal static string Solution(string[] args)
    {
        int safeCounter = 0;

        var lines = Helpers.GetReportLinesFromFile("../../../day-02/input.txt");

        foreach (var line in lines)
        {
            bool isSafe = Helpers.IsLineReportSafe(line);
            if (isSafe) safeCounter++;

            Console.WriteLine($"Report Line: {line} is {(isSafe ? "Safe" : "Unsafe")}");
        }   

        return string.Format("Solution for Day 02: {0} safe reports", safeCounter);
    }

    private class Helpers
    {
        internal static string[] GetReportLinesFromFile(string filePath)
        {
            var lines = Array.Empty<string>();
            using (var reader = new StreamReader(filePath))
            {
                lines = reader.ReadToEnd().Split(Environment.NewLine);
            }

            return lines;
        }

        internal static bool IsLineReportSafe(string reportLine)
        {
            // assume true until proven otherwise
            bool retval = true;

            var parts = reportLine.Split(" ");
            int[] vals = parts.Select(s => Convert.ToInt32(s)).ToArray();
            // intitial validation and establish scale
            if (vals.Length < 2) return false;
            if (vals[0] == vals[1]) return false;
            bool isIncreasing = (vals[0] < vals[1]) ? true : false;

            // TODO: bounds checking
            for (int i = 0; i <= vals.Length - 2; i++)
            {
                // check if the next value is at least 1 but not more than 3 greater than the current value
                int diff = Math.Abs(vals[i] - vals[i + 1]);
                retval = diff >= 1 && diff <= 3;
                if (!retval) break;
                // check if the direction pattern is consistent
                if (vals[i] == vals[i + 1]) return false;
                bool currentlyIsIncreasing = (vals[i] < vals[i + 1]) ? true : false;
                retval = currentlyIsIncreasing == isIncreasing;
                if (!retval) break;
            }

            return retval;
        }
    }
}
