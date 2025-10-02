namespace AdventOfCode2024;

using System;

class Day01
{
    internal static string Solution(string[] args)
    {
        // C:\Users\chris\Documents\GitHub\advent-of-code-2024\bin\Debug\net9.0\day-01\input.txt
        var startList = Common.GetSortedIntegerListFromFile("../../../day-01/input.txt", 0);
        var endList = Common.GetSortedIntegerListFromFile("../../../day-01/input.txt", 1);

        var distance = CalculateDistance(startList, endList);

        return string.Format("Solution for Day 01: Total Distance = {0}", distance);
    }

    private static int CalculateDistance(List<int> start, List<int> end)
    {
        int distance = 0;

        // TODO: Add error handling for lists of different lengths
        for (int i = 0; i < start.Count; i++)
        {
            distance += Math.Abs(start[i] - end[i]);
        }

        return distance;
    }
}