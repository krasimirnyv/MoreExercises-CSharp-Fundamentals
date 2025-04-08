namespace _04.MixedUpLists;

class Program
{
    static void Main(string[] args)
    {
        List<int> firstNumbers = Console.ReadLine()!
            .Split()
            .Select(int.Parse)
            .ToList();
        
        List<int> secondNumbers = Console.ReadLine()!
            .Split()
            .Select(int.Parse)
            .ToList();

        List<int> mergedNumbers = new List<int>();
        int count = Math.Min(firstNumbers.Count, secondNumbers.Count);
        for (int i = count - 1; i >= 0; i--)
        {
            mergedNumbers.Add(firstNumbers[i]);
            mergedNumbers.Add(secondNumbers[secondNumbers.Count - 1 - i]);
        }

        List<int> lastTwoNums = new List<int>();
        if (firstNumbers.Count > secondNumbers.Count)
        {
            lastTwoNums = firstNumbers.TakeLast(2).ToList();
        }
        else // firstNumbers.Count < secondNumbers.Count
        {
            lastTwoNums = secondNumbers.Take(2).ToList();
        }
        
        List<int> result = new List<int>();
        for (int i = 0; i < mergedNumbers.Count; i++)
        {
            if (mergedNumbers[i] > lastTwoNums.Min() 
                && mergedNumbers[i] < lastTwoNums.Max())
            {
                result.Add(mergedNumbers[i]);
            }
        }
        
        result = result.OrderBy(x => x).ToList();
        Console.WriteLine(string.Join(" ", result));
    }
}
