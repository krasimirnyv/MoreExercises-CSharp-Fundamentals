using System.Text;

namespace _04.MorseCodeTranslator;

class Program
{
    static void Main(string[] args)
    {
        string[] morseCodeArray = Console.ReadLine()!
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        StringBuilder decryptedMsg = new StringBuilder(capacity: morseCodeArray.Length);
        foreach (string word in morseCodeArray)
        {
            switch (word) 
            { 
                case ".-":
                    decryptedMsg.Append('A');
                    break;
                case "-...": 
                    decryptedMsg.Append('B');
                    break;
                case "-.-.": 
                    decryptedMsg.Append('C');
                    break;
                case "-..": 
                    decryptedMsg.Append('D');
                    break;
                case ".": 
                    decryptedMsg.Append('E');
                    break;
                case "..-.": 
                    decryptedMsg.Append('F');
                    break;
                case "--.": 
                    decryptedMsg.Append('G');
                    break;
                case "....": 
                    decryptedMsg.Append('H');
                    break;
                case "..": 
                    decryptedMsg.Append('I');
                    break;
                case ".---": 
                    decryptedMsg.Append('J');
                    break;
                case "-.-": 
                    decryptedMsg.Append('K');
                    break;
                case ".-..": 
                    decryptedMsg.Append('L');
                    break;
                case "--": 
                    decryptedMsg.Append('M');
                    break;
                case "-.": 
                    decryptedMsg.Append('N');
                    break;
                case "---": 
                    decryptedMsg.Append('O');
                    break;
                case ".--.": 
                    decryptedMsg.Append('P');
                    break;
                case "--.-": 
                    decryptedMsg.Append('Q');
                    break;
                case ".-.": 
                    decryptedMsg.Append('R');
                    break;
                case "...": 
                    decryptedMsg.Append('S');
                    break;
                case "-": 
                    decryptedMsg.Append('T');
                    break;
                case "..-": 
                    decryptedMsg.Append('U');
                    break;
                case "...-": 
                    decryptedMsg.Append('V');
                    break;
                case ".--": 
                    decryptedMsg.Append('W');
                    break;
                case "-..-": 
                    decryptedMsg.Append('X');
                    break;
                case "-.--": 
                    decryptedMsg.Append('Y');
                    break;
                case "--..": 
                    decryptedMsg.Append('Z');
                    break;
                default: 
                    decryptedMsg.Append(' ');
                    break;
            }
        }

        Console.WriteLine(decryptedMsg.ToString());
    }
}
