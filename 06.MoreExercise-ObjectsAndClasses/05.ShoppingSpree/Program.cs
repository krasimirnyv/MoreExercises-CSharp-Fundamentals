namespace _05.ShoppingSpree;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        InputFormating(people);

        List<Product> products = new List<Product>();
        InputFormating(products);

        string input = default;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();
            string personName = tokens[0];
            string productName = tokens[1];
            
            Person findPerson = people.Find(x => x.Name == personName)!;
            Product findProduct = products.Find(x => x.Name == productName)!;
            if (findPerson.Money >= findProduct.Price)
            {
                findPerson.AddProductInBag(findProduct.Name);
                findPerson.Money -= findProduct.Price;
                Console.WriteLine($"{findPerson.Name} bought {findProduct.Name}");
            }
            else
            {
                Console.WriteLine($"{findPerson.Name} can't afford {findProduct.Name}");
            }
        }

        foreach (Person person in people)
        {
            Console.WriteLine($"{person}");
        }
    }

    private static void InputFormating(List<Person> people)
    {
        string[] sequence = Console.ReadLine()
            .Split(";", StringSplitOptions.RemoveEmptyEntries);

        foreach (string item in sequence)
        {
            string[] info = item
                .Split("=", StringSplitOptions.RemoveEmptyEntries);
            
            string name = info[0];
            decimal money = decimal.Parse(info[1]);
            people.Add(new Person(name, money));
        }
    }
    
    private static void InputFormating(List<Product> products)
    {
        string[] sequence = Console.ReadLine()
            .Split(";", StringSplitOptions.RemoveEmptyEntries);

        foreach (string item in sequence)
        {
            string[] info = item
                .Split("=", StringSplitOptions.RemoveEmptyEntries);
            
            string name = info[0];
            decimal price = decimal.Parse(info[1]);
            products.Add(new Product(name, price));
        }
    }
}

class Person
{
    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        BagOfProducts = new List<string>();
    }

    public string Name { get; set; }
    public decimal Money { get; set; }
    public List<string> BagOfProducts { get; set; }

    public void AddProductInBag(string product)
    {
        BagOfProducts.Add(product);
    }

    public override string ToString()
    {
        return BagOfProducts.Count == 0 ? $"{Name} - Nothing bought" : $"{Name} - {string.Join(", ", BagOfProducts)}";
    }
}

class Product
{
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
}