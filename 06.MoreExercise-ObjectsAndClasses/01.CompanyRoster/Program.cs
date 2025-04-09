namespace _01.CompanyRoster;

class Program
{
    static void Main(string[] args)
    {

        Dictionary<string, List<Employee>> company = new Dictionary<string, List<Employee>>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string department = input[2];
            
            if (!company.ContainsKey(department))
            {
                company[department] = new List<Employee>();
            }
            
            company[department].Add(new Employee(name, salary, department));
        }

        string topDepartment = company
            .OrderByDescending(x => x.Value.Average(employee => employee.Salary))
            .First().Key;

        Console.WriteLine($"Highest Average Salary: {topDepartment}");
        foreach (Employee employee in company[topDepartment]
                     .OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
        }
    }
}

class Employee
{
    public Employee(string name, decimal salary, string department)
    {
        Name = name;
        Salary = salary;
        Department = department;
    }

    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
}