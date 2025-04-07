namespace _03.RecursiveFibonacci;

class Program
{
    static void Main(string[] args)
    {
        int wantedNumber = int.Parse(Console.ReadLine());
        long[] result = new long[wantedNumber + 1];
        Console.WriteLine(GetFibunacci(wantedNumber, result));
    }

    private static long GetFibunacci(int number, long[] result)
    {
        if (number == 1 || number == 2)
        {
            return 1;
        }

        if (result[number] != 0)
        {
            return result[number];
        }
        
        result[number] = GetFibunacci(number - 1, result) + GetFibunacci(number - 2, result);
        return result[number];
    }
}
