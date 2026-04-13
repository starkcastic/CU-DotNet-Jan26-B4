using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();

        leaderboard.Add(55.42, "SwiftRacer");
        leaderboard.Add(52.10, "SpeedDemon");
        leaderboard.Add(58.91, "SteadyEddie");
        leaderboard.Add(51.05, "TurboTom");

        Console.WriteLine("Leaderboard:");
        foreach (var entry in leaderboard)
        {
            Console.WriteLine("Time: " + entry.Key + " sec, Player: " + entry.Value);
        }

        var fastest = leaderboard.First();
        Console.WriteLine("\nGold Medal Time:");
        Console.WriteLine("Time: " + fastest.Key + " sec, Player: " + fastest.Value);

        leaderboard.Remove(58.91);
        leaderboard.Add(54.00, "SteadyEddie");

        Console.WriteLine("\nUpdated Leaderboard:");
        foreach (var entry in leaderboard)
        {
            Console.WriteLine("Time: " + entry.Key + " sec, Player: " + entry.Value);
        }
    }
}