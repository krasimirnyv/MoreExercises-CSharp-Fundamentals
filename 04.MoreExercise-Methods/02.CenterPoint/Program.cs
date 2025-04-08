namespace _02.CenterPoint;

class Program
{
    static void Main(string[] args)
    {
        double x1 = double.Parse(Console.ReadLine()!);
        double y1 = double.Parse(Console.ReadLine()!);
        double x2 = double.Parse(Console.ReadLine()!);
        double y2 = double.Parse(Console.ReadLine()!);

        PrintCenterPoint(x1, y1, x2, y2);
    }

    private static void PrintCenterPoint(double x1, double y1, double x2, double y2)
    {
        double distance1 = GetDistanceToCenter(x1, y1);
        double distance2 = GetDistanceToCenter(x2, y2);

        Console.WriteLine(distance1 <= distance2 ? $"({x1}, {y1})" : $"({x2}, {y2})");
    }

    private static double GetDistanceToCenter(double x, double y)
    {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    }
}
