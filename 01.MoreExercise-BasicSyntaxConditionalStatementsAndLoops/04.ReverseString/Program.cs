namespace _04.ReverseString;

class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        
        char[] charArray = text.ToCharArray();
        Array.Reverse(charArray);
        string revered = new string(charArray);
        
        Console.WriteLine(revered);
    }
}
