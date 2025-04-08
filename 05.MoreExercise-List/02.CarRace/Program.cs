namespace _02.CarRace;

class Program
{
    static void Main(string[] args)
    {
        int[] neededTime = Console.ReadLine()!
            .Split()
            .Select(int.Parse)
            .ToArray();

        double leftRacerTime = 0;
        for (int i = 0; i < neededTime.Length / 2; i++)
        {
            leftRacerTime = ReduceTimeIfZero(neededTime, i, leftRacerTime);
            leftRacerTime += neededTime[i];
        }
        
        double rightRacerTime = 0;
        for (int i = neededTime.Length - 1; i > neededTime.Length / 2; i--)
        {
            rightRacerTime = ReduceTimeIfZero(neededTime, i, rightRacerTime);
            rightRacerTime += neededTime[i];
        }

        if (leftRacerTime < rightRacerTime)
        {
            Console.WriteLine($"The winner is left with total time: {FormatTime(leftRacerTime)}");
        }
        else if (leftRacerTime > rightRacerTime)
        {
            Console.WriteLine($"The winner is right with total time: {FormatTime(rightRacerTime)}");
        }
        else // leftRacerTime == rightRacerTime
        {
            Console.WriteLine($"Left and right are equal with total time: {FormatTime(leftRacerTime)}");
        }
    }
    
    private static double ReduceTimeIfZero(int[] neededTime, int i, double racerTime)
    {
        if (neededTime[i] == 0)
        {
            racerTime *= 0.80;
        }

        return racerTime;
    }
    
    private static string FormatTime(double time)
    {
        return time % 1 == 0 ? ((int)time).ToString() : time.ToString("0.0");    
    }
}