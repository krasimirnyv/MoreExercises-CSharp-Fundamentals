namespace _05.LongestIncreasingSubsequence;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        
        int[] lengthAtIndex = new int[numbers.Length];
        int[] previousIndex = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            lengthAtIndex[i] = 1;
            previousIndex[i] = -1;
        }

        for (int current = 0; current < numbers.Length; current++)
        {
            for (int left = 0; left < current; left++)
            {
                if (numbers[left] < numbers[current] &&
                    lengthAtIndex[left] + 1 > lengthAtIndex[current])
                {
                    lengthAtIndex[current] = lengthAtIndex[left] + 1;
                    previousIndex[current] = left;
                }
            }
        }

        int maxLength = 0;
        int lastIndex = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (lengthAtIndex[i] > maxLength)
            {
                maxLength = lengthAtIndex[i];
                lastIndex = i;
            }
        }
        
        int[] lis = new int[maxLength];
        int position = maxLength - 1;

        while (lastIndex != -1)
        {
            lis[position] = numbers[lastIndex];
            position--;
            lastIndex = previousIndex[lastIndex];
        }

        Console.WriteLine(string.Join(" ", lis));
    }
}
