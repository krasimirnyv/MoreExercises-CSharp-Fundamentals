namespace _02.FromLeftToTheRight;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            long firstNum = long.Parse(input[0]);
            long secondNum = long.Parse(input[1]);
            
            if (firstNum > secondNum)
            {
                SumDigits(Math.Abs(firstNum));
            }
            else // first <= second
            {
                SumDigits(Math.Abs(secondNum));
            }
        }
    }

    private static void SumDigits(long number)
    {
        uint sum = 0;
        while (number > 0)
        {
            short digit = (short)(number % 10);
            sum += (uint)digit;
            number /= 10;
        }
        
        Console.WriteLine(sum);
    }
}