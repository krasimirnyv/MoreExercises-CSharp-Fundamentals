namespace _03.SpeedRacing;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Car> cars = new Dictionary<string, Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] carInfo = Console.ReadLine().Split();
            string model = carInfo[0];
            double fuelAmount = double.Parse(carInfo[1]);
            double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);
            
            cars[model] = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
        }

        string input = default;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commands = input.Split();
            string carModel = commands[1];
            double driveDistance = double.Parse(commands[2]);

            if (cars.ContainsKey(carModel))
            {
                Car car = cars[carModel];
                car.CalculateTraveledDistance(driveDistance);
            }
        }

        foreach (KeyValuePair<string, Car> car in cars)
        {
            Console.WriteLine(car.Value);
        }
    }
}

class Car
{
    public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        TraveledDistance = 0;
    }

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKilometer { get; set; }
    public double TraveledDistance { get; set; }
    
    public void CalculateTraveledDistance(double distance)
    {
        double fuelNeeded = distance * FuelConsumptionPerKilometer;
        if (FuelAmount >= fuelNeeded)
        {
            FuelAmount -= fuelNeeded;
            TraveledDistance += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:F2} {TraveledDistance}";
    }
}