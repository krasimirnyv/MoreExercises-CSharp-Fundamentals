namespace _03.GamingStore;

class Program
{
    static void Main(string[] args)
    {
        decimal balance = decimal.Parse(Console.ReadLine());
        decimal totalSpent = 0;
        
        string input = default;
        while ((input = Console.ReadLine()) != "Game Time")
        {
            decimal price = 0;
            switch (input)
            {
                case "OutFall 4":
                    price = 39.99M;
                    balance = BuyGame(balance, price, input, ref totalSpent);
                    break;
                case "CS: OG":
                    price = 15.99M;
                    balance = BuyGame(balance, price, input, ref totalSpent);
                    break;
                case "Zplinter Zell":
                    price = 19.99M;
                    balance = BuyGame(balance, price, input, ref totalSpent);
                    break;
                case "Honored 2":
                    price = 59.99M;
                    balance = BuyGame(balance, price, input, ref totalSpent);
                    break;
                case "RoverWatch":
                    price = 29.99M;
                    balance = BuyGame(balance, price, input, ref totalSpent);
                    break;
                case "RoverWatch Origins Edition":
                    price = 39.99M;
                    balance = BuyGame(balance, price, input, ref totalSpent);
                    break;
                default:
                    Console.WriteLine("Not Found");
                    break;
            }

            if (balance == 0)
            {
                Console.WriteLine("Out of money!");
                return;
            }
        }

        Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${balance:F2}");
    }

    private static decimal BuyGame(decimal balance, decimal price, string gameName, ref decimal totalSpent)
    {
        if (balance >= price)
        {
            balance -= price;
            totalSpent += price;
            Console.WriteLine($"Bought {gameName}");
        }
        else
        {
            Console.WriteLine("Too Expensive");
        }
        
        return balance;
    }
}