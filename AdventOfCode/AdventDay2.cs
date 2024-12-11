using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeDay2
{
    public class AdventDay2
    {
        static void Main()
        {
            // Input: Each sequence as a line of numbers
            List<string> sequences = new List<string>
            {
                "37 35 34 31 29",
                "99 97 95 93 91 89",
                "8 9 10 11 12 15",
                "60 59 56 55 52 49 48 47",
                "54 53 51 50 48 47",
                "32 35 37 39 40 42"
            };
            foreach (var sequence in sequences)
            {
                // Convert the sequence into a list of integers
                List<int> numbers = sequence.Split(' ').Select(int.Parse).ToList();
                bool isValid = ValidateSequence(numbers);
                Console.WriteLine($"{sequence} -> {(isValid ? "Valid" : "Invalid")}");
            }
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
    }
}
