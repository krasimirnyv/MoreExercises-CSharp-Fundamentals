using System.Text.RegularExpressions;

namespace _04.SantasSecretHelper;

class Program
{
    static void Main(string[] args)
    {
        int key = int.Parse(Console.ReadLine());

        List<string> goodChildren = new List<string>();
        string encryptMsg = default;
        while ((encryptMsg = Console.ReadLine()) != "end")
        {
            char[] symbols = encryptMsg.ToCharArray();
            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = (char)(symbols[i] - key);
            }
            
            string decryptMsg = new string(symbols);
            string pattern = @"\@(?<name>[A-Za-z]+)[^\@|\-|\!|\:|\>]*?\!(?<behavior>[G|N])\!";
            
            Match match = Regex.Match(decryptMsg, pattern);
            if (match.Success
                && match.Groups["behavior"].Value == "G")
            {
                goodChildren.Add(match.Groups["name"].Value);
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, goodChildren));
    }
}
