namespace _04.Snowwhite;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Dwarf> dwarfs = new Dictionary<string, Dwarf>();
        string input = default;
        while ((input = Console.ReadLine()) != "Once upon a time")
        {
            string[] tokens = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            string hatColor = tokens[1];
            string dwarfKey = $"{name}{hatColor}";
            uint physics = uint.Parse(tokens[2]);

            if (dwarfs.ContainsKey(dwarfKey)) // dwarf exist
            {
                if (dwarfs[dwarfKey].Physics < physics) // same hatColor -> choose the better physics
                {
                    dwarfs[dwarfKey].Physics = physics;
                }
            }
            else // dwarf doesn't exist
            {
                dwarfs.Add(dwarfKey, new Dwarf(name, hatColor, physics));
            }
        }
        
        Dictionary<string, int> hatColorCounts = new Dictionary<string, int>();
        foreach (Dwarf dwarf in dwarfs.Values)
        {
            if (!hatColorCounts.ContainsKey(dwarf.HatColor))
            {
                hatColorCounts[dwarf.HatColor] = 0;
            }
            
            hatColorCounts[dwarf.HatColor]++;
        }
        
        Dictionary<string, Dwarf> orderedDwarfs = dwarfs
            .OrderByDescending(x => x.Value.Physics)
            .ThenByDescending(x => hatColorCounts[x.Value.HatColor])
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (KeyValuePair<string,Dwarf> dwarf in orderedDwarfs)
        {
            Console.WriteLine($"({dwarf.Value.HatColor}) {dwarf.Value.Name} <-> {dwarf.Value.Physics}");
        }
    }
}

class Dwarf
{
    public Dwarf(string name, string hatColor, uint physics)
    {
        Name = name;
        HatColor = hatColor;
        Physics = physics;
    }

    public string Name { get; set; }
    public string HatColor { get; set; }
    public uint Physics { get; set; }
}
