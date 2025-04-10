namespace _01.ExtractPersonInformation;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            //Get name
            int startIndex = input.IndexOf('@');
            int endIndex = input.IndexOf('|');
            string name = input.Substring(startIndex + 1, endIndex - startIndex - 1);
            //Get age
            startIndex = input.IndexOf('#');
            endIndex = input.IndexOf('*');
            string age = input.Substring(startIndex + 1, endIndex - startIndex - 1);

            Console.WriteLine($"{name} is {age} years old.");
        }
    }
}
