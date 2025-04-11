using System.Text.RegularExpressions;

namespace _01.WinningTicket;

class Program
{
    static void Main(string[] args)
    {
        string[] tickets = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

        foreach (string rawTicket in tickets)
        {
            string ticket = rawTicket.Trim();
            if (ticket.Length != 20)
            {
                Console.WriteLine("invalid ticket");
                continue;
            }
            
            string leftHalf = ticket[..10];
            string rightHalf = ticket[10..];
            
            string pattern = @"([@#$^])\1{5,9}";
            Regex regex = new Regex(pattern);
            
            Match leftMatch = regex.Match(leftHalf);
            Match rightMatch = regex.Match(rightHalf);
            if (leftMatch.Success && rightMatch.Success
                && leftMatch.Value[0] == rightMatch.Value[0])
            {
                int matchLength = Math.Min(leftMatch.Value.Length, rightMatch.Value.Length);
                Console.WriteLine(matchLength == 10
                    ? $"ticket \"{ticket}\" - {matchLength}{leftMatch.Value[0]} Jackpot!"
                    : $"ticket \"{ticket}\" - {matchLength}{leftMatch.Value[0]}");
            }
            else
            {
                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }
        }
    }
}
