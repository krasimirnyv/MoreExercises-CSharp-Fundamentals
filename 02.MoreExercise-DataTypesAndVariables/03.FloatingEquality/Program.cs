namespace _03.FloatingEquality;

class Program
{
    static void Main(string[] args)
    {
        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());
        
        double difference = Math.Abs(firstNum - secondNum);
        double precision = 0.000001;
        
        if (difference < precision)
        {
            Console.WriteLine("True");
            return;
        }

        Console.WriteLine("False");
        
    }
}