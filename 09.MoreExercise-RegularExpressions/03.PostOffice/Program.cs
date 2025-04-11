using System.Text.RegularExpressions;

namespace _03.PostOffice;

class Program
{
    static void Main(string[] args)
    {
        string[] threePartsText = Console.ReadLine().Split("|");
        
        string firstPartPattern = @"(?<symbol>[\#\$\%\*\&])(?<capital>[A-Z]+)(\k<symbol>)";
        string capitals = Regex.Match(threePartsText[0], firstPartPattern).Groups["capital"].Value;
        
        Dictionary<char, int> letterAndLength = new Dictionary<char, int>();
        string secondPartPattern = @"(?<ascii>[\d]{2})\:(?<length>[\d]{2})";
        
        MatchCollection asciiMatches = Regex.Matches(threePartsText[1], secondPartPattern);
        foreach (Match asciiMatch in asciiMatches)
        {
            int ascii = int.Parse(asciiMatch.Groups["ascii"].Value);
            int length = int.Parse(asciiMatch.Groups["length"].Value) + 1;
            if (ascii is > 64 and < 91)
            {
                char letter = (char)ascii;
                if (capitals.Contains(letter)
                    && !letterAndLength.ContainsKey(letter))
                {
                    letterAndLength.Add(letter, length);
                }
            }
        }

        string[] words = threePartsText[2].Split();

        foreach (char capital in capitals)
        {
            foreach (string word in words)
            {
                if (word.StartsWith(capital)
                    && word.Length == letterAndLength[capital])
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
