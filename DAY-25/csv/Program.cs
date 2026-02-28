using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Player
{
    public string Name { get; set; }
    public int RunsScored { get; set; }
    public int BallsFaced { get; set; }
    public bool IsOut { get; set; }
    public double StrikeRate { get; set; }
    public double Average { get; set; }

    public void CalculateStats()
    {
        if (BallsFaced == 0)
            throw new DivideByZeroException("Balls Faced cannot be zero for Strike Rate calculation.");

        StrikeRate = (double)RunsScored / BallsFaced * 100;

        if (IsOut)
            Average = RunsScored;
        else
            Average = RunsScored;
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Enter CSV file path: ");
        string path = Console.ReadLine();

        List<Player> players = new List<Player>();

        try
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("CSV file not found.");

            foreach (string line in File.ReadLines(path))
            {
                try
                {
                    string[] parts = line.Split(',');

                    string name = parts[0].Trim();
                    int runs = int.Parse(parts[1].Trim());
                    int balls = int.Parse(parts[2].Trim());
                    bool isOut = bool.Parse(parts[3].Trim());

                    Player player = new Player
                    {
                        Name = name,
                        RunsScored = runs,
                        BallsFaced = balls,
                        IsOut = isOut
                    };

                    player.CalculateStats();

                    if (player.BallsFaced >= 10)
                        players.Add(player);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid number format in line: " + line);
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Math error in line: " + line);
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            var sortedPlayers = players
                .OrderByDescending(p => p.StrikeRate)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Name            Runs    SR      Avg");
            Console.WriteLine("---------------------------------------");

            foreach (var p in sortedPlayers)
            {
                Console.WriteLine(
                    $"{p.Name,-15} {p.RunsScored,-7} {p.StrikeRate,6:F2} {p.Average,8:F2}");
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}