using System;
using System.Linq;
using System.Net.Http.Headers;
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
            // our retval
            bool isSafe = true; ;

            var parts = reportLine.Split(" ");
            int[] vals = parts.Select(s => Convert.ToInt32(s)).ToArray();
            // intitial validation and establish scale
            if (vals.Length < 2) return false;
            if (vals[0] == vals[1]) return false;
            bool previousDirection = (vals[0] < vals[1]) ? true : false;

            // TODO: bounds checking
            for (int i = 0; i <= vals.Length - 2; i++)
            {
                // calculate our check values
                bool currentDirection = (vals[i] < vals[i + 1]) ? true : false;
                int diff = Math.Abs(vals[i] - vals[i + 1]);

                // check if the difference is at least 1 but not more than 3
                // check if the direction pattern is consistent
                isSafe = diff >= 1 && diff <= 3 && currentDirection == previousDirection;

                // preserve the direction pattern only if the 2 values are not the same
                if (diff != 0) previousDirection = currentDirection;
                if (!isSafe) break;
            }

            // if (isSafe)
            // {
            //     // let's remove one element at a time and see if we can get a safe result
            //     for (int i = 0; i < vals.Length - 1; i++)   
            //     {
            //         var newParts = parts.Where((source, index) => index != i).ToArray();
            //         isUnsafe = IsLineReportSafe(string.Join(" ", newParts));
            //         if (!isUnsafe) break;
            //     }
            // }

            return isSafe;
        }
    }
}
