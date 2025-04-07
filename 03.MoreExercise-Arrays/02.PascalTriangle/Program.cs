namespace _02.PascalTriangle;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        ulong[][] pascalTriangle = new ulong[lines][];
        for (int row = 0; row < lines; row++)
        {
            pascalTriangle[row] = new ulong[row + 1];
            pascalTriangle[row][0] = 1; // first element is 1
            pascalTriangle[row][^1] = 1; // last element is 1

            for (int col = 1; col < row; col++)
            {
                pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
            }
        }

        for (int row = 0; row < lines; row++)
        {
            Console.WriteLine(string.Join(" ", pascalTriangle[row]));
        }
    }
}
