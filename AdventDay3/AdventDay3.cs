using System;
using System.IO;
using System.Text.RegularExpressions;

public class AdventDay3
{
    public static void Main()
    {
        var filePath = "C:\\Users\\mkeilwert\\Desktop\\Advent2024\\AdventMK24\\Advent24\\AdventDay3\\Day3Input.txt";
        int totalSum = 0;

        try
        {
            var fileContent = File.ReadAllText(filePath);
            var pattern = @"mul\(\s*(\d+)\s*,\s*(\d+)\s*\)";
            var matches = Regex.Matches(fileContent, pattern);
            Console.WriteLine($"Found {matches.Count} matches");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Match: {match.Value}");

                // Extract the two numbers using capturing groups
                if (match.Groups.Count >= 3)
                {
                    int num1 = int.Parse(match.Groups[1].Value);
                    int num2 = int.Parse(match.Groups[2].Value);
                    
                    int product = num1 * num2;
                    totalSum += product;
                    Console.WriteLine($"Numbers: {num1}, {num2} | Product: {product} | Running Total: {totalSum}");
                }
                else
                {
                    Console.WriteLine("Match did not have enough groups!");
                }
            }
            
            Console.WriteLine($"Total Sum of Products: {totalSum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}