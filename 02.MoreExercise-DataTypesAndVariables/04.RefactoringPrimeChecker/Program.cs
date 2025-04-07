namespace _04.RefactoringPrimeChecker;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int currentNum = 2; currentNum <= n; currentNum++)
        {
            bool isPrime = true;
            for (int divider = 2; divider < currentNum; divider++)
            {
                if (currentNum % divider == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine($"{currentNum} -> {isPrime.ToString().ToLower()}");
        }
    }
}
