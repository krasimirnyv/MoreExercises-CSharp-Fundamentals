namespace _02.OldestFamilyMember;

class Program
{
    static void Main(string[] args)
    {
        Family family = new Family();
        
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            byte age = byte.Parse(input[1]);

            family.AddMember(new Person(name, age));
        }
        
        Person oldest = family.GetOldestMember();
        Console.WriteLine($"{oldest.Name} {oldest.Age}");
    }
}

class Person
{
    public Person(string name, byte age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public byte Age { get; set; }
}

class Family
{
    public Family()
    {
        People = new List<Person>();
    }

    public List<Person> People { get; set; }

    public void AddMember(Person person)
    {
        People.Add(person);
    }

    public Person GetOldestMember()
    {
        return People.OrderByDescending(x => x.Age).First();
    }
}

