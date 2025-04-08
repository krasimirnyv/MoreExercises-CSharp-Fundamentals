namespace _03.TakeOrSkipRope;

class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine()!;
        
        List<int> numbers = new List<int>();
        List<char> nonNumbers = new List<char>();
        foreach (char character in text)
        {
            if (int.TryParse(character.ToString(), out int num))
            {
                numbers.Add(num);
                continue;
            }
            
            nonNumbers.Add(character);
        }

        List<int> take = new List<int>();
        List<int> skip = new List<int>();
        for (int index = 0; index < numbers.Count; index++)
        {
            if (index % 2 == 0)
            {
                take.Add(numbers[index]);
                continue;
            }
            
            skip.Add(numbers[index]);
        }

        List<char> result = new List<char>();
        int currentIndex = 0;
        for (int i = 0; i < take.Count; i++)
        {
            // Take
            for (int j = 0; j < take[i] && currentIndex < nonNumbers.Count; j++)
            {
                result.Add(nonNumbers[currentIndex]);
                currentIndex++;
            }

            // Skip
            currentIndex += skip[i];
        }

        Console.WriteLine(string.Join("", result));
    }
}
