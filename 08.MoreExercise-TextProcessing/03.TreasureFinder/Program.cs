namespace _03.TreasureFinder;

class Program
{
    static void Main(string[] args)
    {
        int[] keys = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        
        string input = default;
        while ((input = Console.ReadLine()) != "find")
        {
            char[] charArray = input.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = (char)(charArray[i] - keys[i % keys.Length]);
            }
            
            string decryptedMsg = new string(charArray);
            int startIndex = decryptedMsg.IndexOf('&');
            int endIndex = decryptedMsg.LastIndexOf('&');
            string type = decryptedMsg.Substring(startIndex + 1, endIndex - startIndex - 1);
            
            startIndex = decryptedMsg.IndexOf('<');
            endIndex = decryptedMsg.IndexOf('>');
            string coordinates = decryptedMsg.Substring(startIndex + 1, endIndex - startIndex - 1);

            Console.WriteLine($"Found {type} at {coordinates}");
        }
    }
}
