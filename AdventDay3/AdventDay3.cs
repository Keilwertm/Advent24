using System;
using System.IO;
using System.Text.RegularExpressions;
public class AdventDay3
{
    public static void Main()
    {
        var filePath = "C:\\Users\\keilw\\OneDrive\\Desktop\\AdventCode\\Advent24\\AdventDay3\\Day3Input.txt";
        int totalSum = 0;

        try
        {
            var fileContent = File.ReadAllText(filePath);
            
            // Regex pattern to match 'mul(num1, num2)'
            var pattern = @"mul\((\-?\d+),\s*(\-?\d+)\)";   
           
            var matches = Regex.Matches(fileContent, pattern);

            Console.WriteLine($"Found {matches.Count} matches");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Match: {match.Value}");

                // Ensure at least 3 groups (full match + two numbers)
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
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File not found at path '{filePath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}