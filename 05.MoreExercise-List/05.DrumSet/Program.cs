namespace _05.DrumSet;

class Program
{
    static void Main(string[] args)
    {
        decimal savings = decimal.Parse(Console.ReadLine()!);
        List<int> drumSet = Console.ReadLine()!
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> drumPrices = new List<int>(capacity: drumSet.Count);
        drumPrices.AddRange(drumSet);
        
        string input = default;
        while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
        {
            int hitPower = int.Parse(input);
            ReduceQuality(drumSet, hitPower);
            
            for (int i = 0; i < drumSet.Count; i++)
            {
                if (drumSet[i] > 0)
                {
                    continue;
                }
                
                if (savings >= drumPrices[i] * 3)
                {
                    savings -= drumPrices[i] * 3;
                    drumSet[i] = drumPrices[i];
                }
                else
                {
                    drumSet.RemoveAt(i);
                    drumPrices.RemoveAt(i);
                }
            }
        }

        Console.WriteLine($"{string.Join(" ", drumSet)}\n" +
                          $"Gabsy has {savings:F2}lv.");
        
    }

    private static void ReduceQuality(List<int> drumSet, int hitPower)
    {
        for (int i = 0; i < drumSet.Count; i++)
        {
            drumSet[i] -= hitPower;
        }
    }
}