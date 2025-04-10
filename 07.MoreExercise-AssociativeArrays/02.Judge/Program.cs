namespace _02.Judge;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<User>> users = new Dictionary<string, List<User>>();
        string input = default;
        while ((input = Console.ReadLine()) != "no more time")
        {
            string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            string username = tokens[0];
            string contest = tokens[1];
            int points = int.Parse(tokens[2]);

            if (users.ContainsKey(contest))
            {
                bool isExist = users[contest].Exists(x => x.Username == username);
                if (isExist)
                {
                    User user = users[contest].First(x => x.Username == username);
                    if (user.Points < points)
                    {
                        user.Points = points;
                    }
                }
                else
                {
                    users[contest].Add(new User(username, points));
                }
            }
            else
            {
                users.Add(contest, new List<User>());
                users[contest].Add(new User(username, points));
            }
        }

        int index;
        foreach (KeyValuePair<string,List<User>> pair in users)
        {
            List<User> orderedUsers = pair.Value.OrderByDescending(x => x.Points)
                .ThenBy(x => x.Username)
                .ToList();
            
            index = 1;
            Console.WriteLine($"{pair.Key}: {pair.Value.Count} participants");
            foreach (User user in orderedUsers)
            {
                Console.WriteLine($"{index++}. {user.Username} <::> {user.Points}");
            }
        }
        
        Console.WriteLine("Individual standings:");
        Dictionary<string, int> individuals = new Dictionary<string, int>();
        foreach (List<User> contest in users.Values)
        {
            foreach (User user in contest)
            {
                if (!individuals.ContainsKey(user.Username))
                {
                    individuals[user.Username] = 0;
                }
                
                individuals[user.Username] += user.Points;
            }
        }

        Dictionary<string, int> sortedIndividuals = individuals
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        index = 1;
        foreach (KeyValuePair<string, int> pair in sortedIndividuals)
        {
            Console.WriteLine($"{index++}. {pair.Key} -> {pair.Value}");
        }
    }
}

class User
{
    public User(string username, int points)
    {
        Username = username;
        Points = points;
    }

    public string Username { get; set; }
    public int Points { get; set; }
}
