namespace _03.MOBAChallenger;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Player> players = new Dictionary<string, Player>();
        string input = default;
        while ((input = Console.ReadLine()) != "Season end")
        {
            if (input.Contains(" vs ")) // we receive "player vs player"
            {
                string[] tokens = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                string firstPlayer = tokens[0];
                string secondPlayer = tokens[1];

                Battle(players, firstPlayer, secondPlayer);
            }
            else // we receive "player -> position -> skill"
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string player = tokens[0];
                string position = tokens[1];
                int skill = int.Parse(tokens[2]);

                AddPlayer(players, player, position, skill);
            }
        }

        PrintInOrder(players);
    }
    
    private static void Battle(Dictionary<string, Player> players, string firstPlayer, string secondPlayer)
    {
        if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer))
        {
            Dictionary<string, int>.KeyCollection firstPositions = players[firstPlayer].PositionsSkills.Keys;
            Dictionary<string, int>.KeyCollection secondPositions = players[secondPlayer].PositionsSkills.Keys;

            if (firstPositions.Intersect(secondPositions).Any())
            {
                int firstSkill = players[firstPlayer].TotalSkill;
                int secondSkill = players[secondPlayer].TotalSkill;
                if (firstSkill > secondSkill)
                {
                    players.Remove(secondPlayer);
                }
                else if (secondSkill > firstSkill)
                {
                    players.Remove(firstPlayer);
                }
            }
        }
    }

    private static void AddPlayer(Dictionary<string, Player> players, string player, string position, int skill)
    {
        if (!players.ContainsKey(player))
        {
            players[player] = new Player(player);
        }

        if (!players[player].PositionsSkills.ContainsKey(position))
        {
            players[player].PositionsSkills[position] = skill;
        }
        else if (players[player].PositionsSkills[position] < skill)
        {
            players[player].PositionsSkills[position] = skill;
        }
    }
    
    private static void PrintInOrder(Dictionary<string, Player> players)
    {
        Dictionary<string,Player> sortedPlayers = players.OrderByDescending(x => x.Value.TotalSkill)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (KeyValuePair<string, Player> player in sortedPlayers)
        {
            Console.WriteLine($"{player.Key}: {player.Value.TotalSkill} skill");
            
            Dictionary<string,int> sortedIndividuals = player.Value.PositionsSkills
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var position in sortedIndividuals)
            {
                Console.WriteLine($"- {position.Key} <::> {position.Value}");
            }
        }
    }
}

class Player
{
    public Player(string name) 
    { 
        Name = name; 
        PositionsSkills = new Dictionary<string, int>();
    }
    
    public string Name { get; set; } 
    public Dictionary<string, int> PositionsSkills { get; set; }
    public int TotalSkill => PositionsSkills.Values.Sum();
}