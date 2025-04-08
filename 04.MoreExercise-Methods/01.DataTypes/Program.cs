namespace _01.DataTypes;

class Program
{
    static void Main(string[] args)
    {
        string dataType = Console.ReadLine()!;
        string value = Console.ReadLine()!;

        switch (dataType)
        {
            case "int":
                PrintResults(int.Parse(value));
                break;
            case "real":
                PrintResults(double.Parse(value));
                break;
            case "string":
                PrintResults(value);
                break;
        }
    }

    private static void PrintResults(int value)
    {
        value *= 2;
        Console.WriteLine(value);
    }
    
    private static void PrintResults(double value)
    {
        value *= 1.5;
        Console.WriteLine($"{value:F2}");
    }
    private static void PrintResults(string value)
    {
        Console.WriteLine($"${value}$");
    }
    
}
