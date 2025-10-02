namespace AdventOfCode2024;

using System;

public class Day01
{
    internal static string Solution(string[] args)
    {
        // C:\Users\chris\Documents\GitHub\advent-of-code-2024\bin\Debug\net9.0\day-01\input.txt
        var startList = Helpers.GetSortedIntegerListFromFile("../../../day-01/input.txt", 0);
        var endList = Helpers.GetSortedIntegerListFromFile("../../../day-01/input.txt", 1);

        //var distance = Helpers.CalculateDistance(startList, endList);
        //return string.Format("Solution for Day 01: Total Distance = {0}", distance);

        var similarity = Helpers.CalculateSimilarity(startList, endList);
        return string.Format("Solution for Day 01: Total Similarity = {0}", similarity);
    }

    private class Helpers
    {
        internal static List<int> GetSortedIntegerListFromFile(string filePath, int position)
        {
            var lines = Array.Empty<string>();
            using (var reader = new StreamReader(filePath))
            {
                lines = reader.ReadToEnd().Split(Environment.NewLine);
            }

            var numbers = new List<int>();
            foreach (var line in lines)
            {
                var parts = line.Split("   ");
                if (parts.Length > position && int.TryParse(parts[position], out int number))
                {
                    numbers.Add(number);
                }
            }

            numbers.Sort();
            //Console.WriteLine(string.Join(", ", numbers));
            return numbers;
        }
        
        internal static int CalculateDistance(List<int> start, List<int> end)
        {
            int distance = 0;

            // TODO: Add error handling for lists of different lengths
            for (int i = 0; i < start.Count; i++)
            {
                distance += Math.Abs(start[i] - end[i]);
            }

            return distance;
        }

        internal static int CalculateSimilarity(List<int> searchValues, List<int> searchList)
        {
            int similarity = 0;

            foreach (var value in searchValues)
            {
                int count = System.Linq.Enumerable.Count(searchList, x => x == value);

                similarity += value * count;
            }

            return similarity;
        }
    }
}