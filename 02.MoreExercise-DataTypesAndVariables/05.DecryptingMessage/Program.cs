using System.Text;

namespace _05.DecryptingMessage;

class Program
{
    static void Main(string[] args)
    {
        ushort key = ushort.Parse(Console.ReadLine());
        uint lines = uint.Parse(Console.ReadLine());
        StringBuilder messageBuilder = new StringBuilder(capacity: (int)lines);
        for (int i = 0; i < lines; i++)
        {
            char letter = char.Parse(Console.ReadLine());
            char decryptedLetter = (char)(letter + key);
            messageBuilder.Append(decryptedLetter);
        }
        
        Console.WriteLine(messageBuilder.ToString());
    }
}
