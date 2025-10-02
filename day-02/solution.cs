using System;
using System.ComponentModel;
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
            List<int> reportLineValues = line.Split(" ").Select(s => Convert.ToInt32(s)).ToList();
            //bool isSafe = Helpers.IsLineReportSafe(reportLineValues);
            bool isSafe = Helpers.IsLineReportTolerablySafe(reportLineValues);
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

        internal static bool IsLineReportSafe(List<int> reportLine)
        {
            // our retval
            bool isSafe = true;

            // intitial validation and establish scale
            if (reportLine.Count < 2) return false;
            if (reportLine[0] == reportLine[1]) return false;
            bool previousDirection = (reportLine[0] < reportLine[1]) ? true : false;

            for (int i = 0; i <= reportLine.Count - 2; i++)
            {
                // calculate our check values
                bool currentDirection = (reportLine[i] < reportLine[i + 1]) ? true : false;
                int diff = Math.Abs(reportLine[i] - reportLine[i + 1]);

                // check if the difference is at least 1 but not more than 3
                // check if the direction pattern is consistent
                isSafe = diff >= 1 && diff <= 3 && currentDirection == previousDirection;

                // preserve the direction pattern only if the 2 values are not the same
                if (diff != 0) previousDirection = currentDirection;
                if (!isSafe) break;
            }

            return isSafe;
        }

        internal static bool IsLineReportTolerablySafe(List<int> reportLine)
        {
            if (IsLineReportSafe(reportLine)) return true;

            // our retval
            bool isSafe = false;

            // let's remove one element at a time and see if we can get a safe result
            for (int i = 0; i < reportLine.Count; i++)
            {
                var modifiedLine = reportLine.Where((source, index) => index != i).ToList();
                isSafe = IsLineReportSafe(modifiedLine);
                if (isSafe) break;
            }

            return isSafe;
        }
    }
}
