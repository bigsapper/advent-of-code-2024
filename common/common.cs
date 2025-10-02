using System;
using System.Diagnostics;

namespace AdventOfCode2024;

public class Common
{
    public static List<int> GetSortedIntegerListFromFile(string filePath, int position)
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
}
