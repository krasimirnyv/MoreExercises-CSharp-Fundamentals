namespace _04.TribonacciSequence;

class Program
{
    static void Main(string[] args)
    {
        uint num = uint.Parse(Console.ReadLine()!);
        ulong[] tribonacciArray = new ulong[num];
        
        PrintTribonacciSequence(tribonacciArray);
    }

    private static void PrintTribonacciSequence(ulong[] tribonacci)
    {
        for (int index = 0; index < tribonacci.Length; index++)
        {
            if (index is 0 or 1)
            {
                tribonacci[index] = 1;
            }
            else if (index is 2)
            {
                tribonacci[index] = tribonacci[index - 1] + tribonacci[index - 2];
            }
            else // index is more than 2
            {
                tribonacci[index] = tribonacci[index - 1] + tribonacci[index - 2] + tribonacci[index - 3];
            }
        }

        Console.WriteLine(string.Join(" ", tribonacci));
    }
}
