using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    public static void Main()
    {
        
        string filePath = "C:\\Users\\mkeilwert\\Desktop\\Advent2024\\AdventMK24\\Advent24\\AdventDay2\\Day2Input.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }
        // List to store sequences from the file
        List<string> sequences = new List<string>();
        // Read sequences from the file
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    sequences.Add(line.Trim());
                }
            }
        }
        int validCount = 0, safeCount = 0, unsafeCount = 0;

        // Process each sequence
        foreach (var sequence in sequences)
        {
            // Convert the sequence into a list of integers
            List<int> numbers = sequence.Split(' ').Select(int.Parse).ToList();

            if (ValidateSequence(numbers))
            {
                Console.WriteLine($"{sequence} -> Valid");
                validCount++;
            }
            else if (CanBeSafeByRemovingOne(numbers))
            {
                Console.WriteLine($"{sequence} -> Safe");
                safeCount++;
            }
            else
            {
                Console.WriteLine($"{sequence} -> Unsafe");
                unsafeCount++;
            }
        }
        Console.WriteLine($"Total valid sequences: {validCount}");
        Console.WriteLine($"Total safe sequences: {safeCount}");
        Console.WriteLine($"Total unsafe sequences: {unsafeCount}");
    }

    static bool ValidateSequence(List<int> numbers)
    {
        if (numbers.Count < 2) return true; // Single number is valid by default

        // Determine if the sequence is increasing or decreasing
        bool isIncreasing = numbers[1] > numbers[0];
        bool isDecreasing = numbers[1] < numbers[0];

        for (int i = 1; i < numbers.Count; i++)
        {
            int difference = numbers[i] - numbers[i - 1];

            // Check if the difference is between 1 and 3
            if (Math.Abs(difference) < 1 || Math.Abs(difference) > 3)
            {
                return false;
            }
            // Check if the sequence is consistently increasing or decreasing
            if (isIncreasing && difference <= 0)
            {
                return false;
            }
            else if (isDecreasing && difference >= 0)
            {
                return false;
            }
        }
        return true;
    }

    static bool CanBeSafeByRemovingOne(List<int> numbers)
    {
        // Try removing each number in the sequence and validate
        for (int i = 0; i < numbers.Count; i++)
        {
            // Create a new list excluding the current number
            List<int> modifiedSequence = numbers.Where((_, index) => index != i).ToList();

            if (ValidateSequence(modifiedSequence))
            {
                return true;
            }
        }
        return false; 
    }
}
