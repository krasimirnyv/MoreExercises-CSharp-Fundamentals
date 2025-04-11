using System.Text;
using System.Text.RegularExpressions;

namespace _02.RageQuit;

class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine()!.ToLower();
        string pattern = @"(?<symbols>\D+)(?<digit>\d+)";
        
        StringBuilder result = new StringBuilder(capacity: text.Length);
        HashSet<char> uniqueSymbols = new HashSet<char>();

        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            string word = match.Groups["symbols"].Value;
            int digit = int.Parse(match.Groups["digit"].Value);
            
            for (int i = 0; i < digit; i++)
            {
                result.Append(word);
            }
        }
        
        foreach (char symbol in result.ToString())
        {
            uniqueSymbols.Add(symbol);
        }

        Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}\n" +
                          $"{result.ToString().ToUpper()}");
    }
}
