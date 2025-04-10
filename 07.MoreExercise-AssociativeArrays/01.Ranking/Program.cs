namespace _01.Ranking;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> contests = new Dictionary<string, string>();
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "end of contests")
        {
            string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
            string contest = tokens[0];
            string password = tokens[1];
            
            contests.Add(contest, password);
        }
        
        SortedDictionary<string, User> users = new SortedDictionary<string, User>();
        input = string.Empty;
        while ((input = Console.ReadLine()) != "end of submissions")
        {
            string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
            string contest = tokens[0];
            string password = tokens[1];
            string username = tokens[2];
            int points = int.Parse(tokens[3]);

            if (contests.ContainsKey(contest)
                && contests[contest] == password)
            {
                if (users.ContainsKey(username) 
                    && users[username].ContestsAndPoints.ContainsKey(contest))
                {
                    if (users[username].ContestsAndPoints[contest] < points)
                    {
                        users[username].ContestsAndPoints[contest] = points;
                    }
                    
                    continue;
                }

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new User(username));
                }
                
                users[username].AddContest(contest, points);
            }
        }

        string bestCandidate = users
            .OrderByDescending(x => x.Value.ContestsAndPoints.Values.Sum())
            .Select(x => x.Key)
            .First();
        
        int bestPoints = users[bestCandidate].ContestsAndPoints.Values.Sum();

        Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.\n" +
                          $"Ranking: ");

        foreach (KeyValuePair<string,User> user in users)
        {
            Console.WriteLine(user.Key);
            Console.WriteLine(user.Value);
        }
    }
}

class User
{
    public User(string username)
    {
        Username = username;
        ContestsAndPoints = new Dictionary<string, int>();
    }

    public string Username { get; set; }
    public Dictionary<string, int> ContestsAndPoints { get; set; }

    public void AddContest(string contest, int points)
    {
        ContestsAndPoints.Add(contest, points);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine,
                ContestsAndPoints.OrderByDescending(x => x.Value)
                    .Select(x => $"#  {x.Key} -> {x.Value}"));
    }
}