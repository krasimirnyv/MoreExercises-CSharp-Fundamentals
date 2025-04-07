namespace _01.EncryptSortАndPrintArray;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        int[] values = new int[lines];
        for (int i = 0; i < lines; i++)
        {
            int sum = 0;
            string word = Console.ReadLine();
            foreach (char currentLetter in word)
            {
                // vowel letters: a, e, i, o, u.
                if (currentLetter is 'A' or 'a' or 'E' or 'e' or 'I' or 'i' or 'O' or 'o' or 'U' or 'u')
                {
                    sum += currentLetter * word.Length;
                }
                else // consonant letters
                {
                    sum += currentLetter / word.Length;
                }
            }

            values[i] = sum;
        }
        
        for (int i = 0; i < values.Length - 1; i++)
        {
            for (int j = i + 1; j < values.Length; j++)
            {
                if (values[i] > values[j])
                {
                    (values[i], values[j]) = (values[j], values[i]);
                }
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, values));
    }
}
