namespace _01.DataTypeFinder;

class Program
{
    static void Main(string[] args)
    {
        string input = default;
        while ((input = Console.ReadLine()) != "END"
               && input != null)
        {
            bool isSpecified = false;
            isSpecified = IntegerType(input);
            if (isSpecified)
                continue;
            
            isSpecified = FloatingPointType(input);
            if (isSpecified)
                continue;
            
            isSpecified =  CharacterType(input);
            if (isSpecified)
                continue;
            
            isSpecified = BooleanType(input);
            if (isSpecified)
                continue;
            
            StringType(input);
        }
    }

    private static bool IntegerType(string input)
    {
        bool isInt = int.TryParse(input, out _);
        if (isInt)
        {
            Console.WriteLine($"{input} is integer type");
            return true;
        }
        
        return false;
    }
    
    private static bool FloatingPointType(string input)
    {
        bool isFloat = double.TryParse(input, out _);
        if (isFloat)
        {
            Console.WriteLine($"{input} is floating point type");
            return true;
        }
        
        return false;
    }
    
    private static bool CharacterType(string input)
    {
        bool isChar = char.TryParse(input, out _);
        if (isChar)
        {
            Console.WriteLine($"{input} is character type");
            return true;
        }
        
        return false;
    }
    
    private static bool BooleanType(string input)
    {
        bool isBool = bool.TryParse(input, out _);
        if (isBool)
        {
            Console.WriteLine($"{input} is boolean type");
            return true;
        }
        
        return false;
    }
    
    private static void StringType(string input)
    {
        bool isNullOrEmpty = string.IsNullOrEmpty(input);
        if (!isNullOrEmpty)
        {
            Console.WriteLine($"{input} is string type");
        }
    }
}
