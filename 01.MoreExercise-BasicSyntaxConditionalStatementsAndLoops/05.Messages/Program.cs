using System.Text;

namespace _05.Messages;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        StringBuilder sms = new StringBuilder(capacity: lines);
        
        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            int clicks = input.Length;
            char digit = input[0];

            switch (digit)
            {
                case '0':
                    sms.Append(' ');
                    break;
                case '2':
                    sms.Append((char)(96 + clicks));
                    break;
                case '3':
                    sms.Append((char)(99 + clicks));
                    break;
                case '4':
                    sms.Append((char)(102 + clicks));
                    break;
                case '5':
                    sms.Append((char)(105 + clicks));
                    break;
                case '6':
                    sms.Append((char)(108 + clicks));
                    break;
                case '7':
                    sms.Append((char)(111 + clicks));
                    break;
                case '8':
                    sms.Append((char)(115 + clicks));
                    break;
                case '9':
                    sms.Append((char)(118 + clicks));
                    break;
            }
        }

        Console.WriteLine(sms.ToString());
    }
}