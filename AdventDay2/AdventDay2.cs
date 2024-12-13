public class AdventDay2
{
    public static void Main()
    {
        string filePath = "C:\\Users\\mkeilwert\\Desktop\\Advent2024\\AdventMK24\\Advent24\\AdventDay2\\Day2Input.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }
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
        int validCount = 0;
        
        foreach (var sequence in sequences)
        {
            // Convert the sequence into a list of integers
            List<int> numbers = sequence.Split(' ').Select(int.Parse).ToList();
            bool isValid = ValidateSequence(numbers);
            if (isValid)
            {
                validCount++;
            }
            Console.WriteLine($"{sequence} -> {(isValid ? "Valid" : "Invalid")}");
        }
        Console.WriteLine($"Total valid sequences: {validCount}");
    }
    static bool ValidateSequence(List<int> numbers)
    {
        if (numbers.Count < 2) return true; 
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