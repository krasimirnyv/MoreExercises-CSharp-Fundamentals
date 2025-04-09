namespace _04.RawData;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        uint lines = uint.Parse(Console.ReadLine());
        for (uint i = 0; i < lines; i++)
        {
            string[] info = Console.ReadLine().Split();
            string model = info[0];
            uint engineSpeed = uint.Parse(info[1]);
            uint enginePower = uint.Parse(info[2]);
            uint cargoWeight = uint.Parse(info[3]);
            string cargoType = info[4];
            
            cars.Add(new Car(model, new Engine(engineSpeed, enginePower), new Cargo(cargoWeight, cargoType)));
        }
        
        string command = Console.ReadLine().ToLower();
        PrintCarsByCommand(command, cars);
    }

    private static void PrintCarsByCommand(string command, List<Car> cars)
    {
        if (command == CargoType.fragile.ToString())
        { 
            List<string> fragileCargo = cars.Where(x => x.Cargo is
            {
                Type: CargoType.fragile,
                Weight: < 1000 
            }).Select(x => x.Model).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragileCargo));
        }
        else if (command == CargoType.flamable.ToString())
        {
            List<string> flamableCargo = cars.Where(x => x.Cargo.Type == CargoType.flamable && x.Engine.Power > 250)
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamableCargo));
        }
    }
}

class Car
{
    public Car(string model, Engine engine, Cargo cargo)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
}

class Engine
{
    public Engine(uint speed, uint power)
    {
        Speed = speed;
        Power = power;
    }

    public uint Speed { get; set; }
    public uint Power { get; set; }
}

class Cargo
{
    public Cargo(uint weight, string type)
    {
        Weight = weight;
        Type = type == "fragile" ? CargoType.fragile : CargoType.flamable;
    }

    public uint Weight { get; set; }
    public CargoType Type { get; set; }
}

public enum CargoType
{
    fragile,
    flamable
}
