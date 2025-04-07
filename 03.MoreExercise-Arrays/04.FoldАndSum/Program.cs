namespace _04.FoldАndSum;

class Program
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        
        // the first quarter of the array
        int index = 0;
        int[] beginning = new int[array.Length / 4];
        for (int i = array.Length / 4 - 1; i >= 0; i--)
        {
            beginning[index] = array[i];
            index++;
        }
        
        // the last quarter of the array
        index = 0;
        int[] ending = new int[array.Length / 4];
        for (int i = array.Length - 1; i >= array.Length / 4 * 3; i--)
        {
            ending[index] = array[i];
            index++;
        }
        
        // remaining two quarters in the middle of the array
        index = 0;
        int[] remaining = new int[array.Length / 2];
        for (int i = array.Length / 4; i < array.Length / 4 * 3; i++)
        {
            remaining[index] = array[i];
            index++;
        }

        // sum the first pairs
        int[] result = new int[array.Length / 2];
        for (int i = 0; i < beginning.Length; i++)
        {
            result[i] = beginning[i] + remaining[i];
        }
        
        // sum the last pairs
        index = 0;
        for (int i = remaining.Length / 2; i < remaining.Length; i++)
        {
            result[i] = remaining[i] + ending[index];
            index++;
        }

        Console.WriteLine(string.Join(" ", result));
    }
}