using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace AdventOfCode2024;

public class Day03
{
    internal static string Solution(string[] args)
    {

        return "";
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

        internal static bool boop()
        {
            return true;
        }
    }
}
