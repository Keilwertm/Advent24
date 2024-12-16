using System.Text.RegularExpressions;

public class AdventDay3
{
    public static void Main()
    {
        var filePath = "C:\\Users\\mkeilwert\\Desktop\\Advent2024\\AdventMK24\\Advent24\\AdventDay3\\Day3Input.txt";

        try
        {
            var fileContent = File.ReadAllText(filePath);
            var pattern = "mul(int, int.Parse(fileContent))";

            var matches = Regex.Matches(fileContent, pattern);
            Console.WriteLine($"Found {matches.Count} matches");
            foreach (Match match in matches) Console.WriteLine(match.Value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}