namespace _05.DragonArmy;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, Dragon>> dragonsByType = new Dictionary<string, Dictionary<string, Dragon>>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split();
            string type = input[0];
            string name = input[1];
            
            bool isParsing = int.TryParse(input[2], out int damage);
            if (!isParsing)
            {
                damage = 45;
            }
            
            isParsing = int.TryParse(input[3], out int health);
            if (!isParsing)
            {
                health = 250;
            }
            
            isParsing = int.TryParse(input[4], out int armor);
            if (!isParsing)
            {
                armor = 10;
            }

            if (!dragonsByType.ContainsKey(type))
            {
                dragonsByType[type] = new Dictionary<string, Dragon>();
            }
            
            dragonsByType[type][name] = new Dragon(type, name, damage, health, armor);
        }

        foreach (KeyValuePair<string,Dictionary<string,Dragon>> typePair in dragonsByType)
        {
            Dictionary<string, Dragon> dragons = typePair.Value;
            
            double averageDamage = dragons.Values.Average(x => x.Damage);
            double averageHealth = dragons.Values.Average(x => x.Health);
            double averageArmor = dragons.Values.Average(x => x.Armor);

            Console.WriteLine($"{typePair.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

            Dictionary<string,Dragon> sortedDragons = dragons.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (KeyValuePair<string, Dragon> dragon in sortedDragons)
            {
                Dragon d = dragon.Value;
                Console.WriteLine($"-{d.Name} -> damage: {d.Damage}, health: {d.Health}, armor: {d.Armor}");
            }
        }
    }
}

class Dragon
{
    public Dragon(string type, string name, int damage, int health, int armor)
    {
        Type = type;
        Name = name;
        Damage = damage;
        Health = health;
        Armor = armor;
    }

    public string Type { get; set; }
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Health { get; set; }
    public int Armor { get; set; }
}