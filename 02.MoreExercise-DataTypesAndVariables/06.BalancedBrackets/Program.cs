namespace _06.BalancedBrackets;

class Program
{
    static void Main(string[] args)
    {
        int bracketCount = 0;
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            if (input == "(")
            {
                bracketCount++;
                if (bracketCount > 1)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
            }
            else if(input == ")")
            {
                bracketCount--;
                if (bracketCount < 0)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
            }
        }
        
        if (bracketCount != 0)
        {
            Console.WriteLine("UNBALANCED");
        }
        else
        {
            Console.WriteLine("BALANCED");
        }

    }
}