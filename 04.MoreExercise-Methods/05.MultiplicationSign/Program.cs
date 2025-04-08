namespace _05.MultiplicationSign;

class Program
{
    static void Main(string[] args)
    {
        int num1 = int.Parse(Console.ReadLine()!);
        int num2 = int.Parse(Console.ReadLine()!);
        int num3 = int.Parse(Console.ReadLine()!);
        
        PrintResult(num1, num2, num3);
    }

    private static void PrintResult(int num1, int num2, int num3)
    {
        if (CheckForZeroOutput(num1, num2, num3))
        {
            Console.WriteLine("zero");
            return;
        }
        
        bool isNegative = IsNegativeOutput(num1, num2, num3);
        Console.WriteLine(isNegative ? "negative" : "positive");
    }

    private static bool CheckForZeroOutput(int num1, int num2, int num3)
    {
        return num1 == 0 || num2 == 0 || num3 == 0;
    }

    private static bool IsNegativeOutput(int num1, int num2, int num3)
    {
        byte minusCount = 0;
        NegativeNumber(num1, ref minusCount);
        NegativeNumber(num2, ref minusCount);
        NegativeNumber(num3, ref minusCount);
        
        return minusCount % 2 != 0;
    }

    private static void NegativeNumber(int num, ref byte minusCount)
    {
        if (num < 0)
        {
            minusCount++;
        }
    }
}