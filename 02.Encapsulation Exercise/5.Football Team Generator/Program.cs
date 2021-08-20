using System;
using System.Collections.Generic;

namespace _5.FootballTeamGenerator
{
    public class Program
    {
        static void Main()
        {
            var teamsByName = new Dictionary<string, Team>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var parts = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var command = parts[0];

                try
                {
                    if (command == "Add")
                    {
                        var teamName = parts[1];

                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        var playerName = parts[2];
                        var endurance = int.Parse(parts[3]);
                        var sprint = int.Parse(parts[4]);
                        var dribble = int.Parse(parts[5]);
                        var passing = int.Parse(parts[6]);
                        var shooting = int.Parse(parts[7]);

                        var team = teamsByName[teamName];

                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        var teamName = parts[1];
                        var playerName = parts[2];

                        var team = teamsByName[teamName];
                        team.RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {
                        var teamName = parts[1];
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        var team = teamsByName[teamName];
                        Console.WriteLine($"{teamName} - {team.AverageRating}");
                    }
                    else if (command == "Team")
                    {
                        var teamName = parts[1];

                        var team = new Team(teamName);

                        teamsByName.Add(teamName, team);
                    }
                }
                catch (Exception ex)
                when(ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
