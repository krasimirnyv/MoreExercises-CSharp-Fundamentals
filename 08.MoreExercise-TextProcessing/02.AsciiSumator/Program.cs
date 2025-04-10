namespace _02.AsciiSumator;

class Program
{
    static void Main(string[] args)
    {
        char firstChar = char.Parse(Console.ReadLine()!);
        char secondChar = char.Parse(Console.ReadLine()!);
        
        char bigger = (char)Math.Max(firstChar, secondChar);
        char smaller = (char)Math.Min(firstChar, secondChar);
        
        string input = Console.ReadLine()!;

        uint sum = 0;
        foreach (char ch in input)
        {
            if (ch > smaller && ch < bigger)
            {
                sum += ch;
            }
        }

        Console.WriteLine(sum);
    }
}
