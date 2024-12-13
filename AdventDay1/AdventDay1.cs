using System.Collections.Generic;
using System.Linq;
    public class AdventDay1
    {
        static void Main()
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int totalDistance = 0;
            int totalOccurrences = 0;

            try
            {
                // "Using" statement cleans up
                using (StreamReader sr =
                       new StreamReader(
                           "C:\\Users\\mkeilwert\\Desktop\\Advent2024\\AdventMK24\\Advent24\\AdventDay1\\Day1Input.txt"))
                {
                    string line;
                    while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                    {
                        // Split based on three spaces
                        string[] parts = line.Split(new[] { "   " }, StringSplitOptions.None);
                        if (parts.Length == 2) // Ensure two parts exist
                        {
                            left.Add(int.Parse(parts[0]));
                            right.Add(int.Parse(parts[1]));
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line format: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
            left.Sort();
            right.Sort();
            for (int i = 0; i < left.Count; i++)
            {
                totalDistance += Math.Abs(left[i] - right[i]);
            }
            Console.WriteLine($"Part 1: {totalDistance}");
            Dictionary<int, int> counts = new Dictionary<int, int>();
            int result = 0; // To store the final sum

            foreach (int num in left)
            {
                if (!counts.ContainsKey(num))
                {
                    counts[num] = right.FindAll(x => x == num).Count;
                }
                // Multiply the number by its count and add to the result
                result += num * counts[num];
            }
            Console.WriteLine($"Part 2: {result}");
        }
    }