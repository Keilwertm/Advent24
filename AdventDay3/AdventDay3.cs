﻿using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class AdventDay3
{
    public static void Main()
    {
        var filePath = "C:\\Users\\mkeilwert\\Desktop\\Advent2024\\AdventMK24\\Advent24\\AdventDay3\\Day3Input.txt";

        try
        {
            // Read all content from the file
            var fileContent = File.ReadAllText(filePath);

            // Regex pattern to match "mul(X, Y)" where X and Y are integers
            var pattern = @"mul\(\d+,\s*\d+\)";
            
            // Find matches in the file content
            var matches = Regex.Matches(fileContent, pattern);

            // Print the number of matches found
            Console.WriteLine($"Found {matches.Count} matches");

            // Print each match
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors during file reading or processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
