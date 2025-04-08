namespace _01.Messaging;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()!
            .Split()
            .Select(int.Parse)
            .ToList();
        
        string text = Console.ReadLine()!;

        List<int> indices = new List<int>(capacity: numbers.Count);
        ConvertingNumbersToIndices(numbers, indices);

        string result = string.Empty;
        result = GetResult(indices, text, result);
        
        Console.WriteLine(result);
    }
    
    private static void ConvertingNumbersToIndices(List<int> numbers, List<int> indexes)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            int sum = 0;
            while (numbers[i] != 0)
            {
                int digit = numbers[i] % 10;
                sum += digit;
                numbers[i] /= 10;
            }
            
            indexes.Add(sum);
        }
    }
    
    private static string GetResult(List<int> indices, string text, string result)
    {
        for (int i = 0; i < indices.Count; i++)
        {
            while (indices[i] >= text.Length)
            {
                indices[i] -= text.Length;
            }
            
            result += text[indices[i]];
            text = text.Remove(indices[i],1);
        }

        return result;
    }
}