using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        string filePath = "journal.txt";

        Console.WriteLine("Daily Logger");
        Console.WriteLine("------------------------");
        Console.Write("Write your Daily Reflection: ");
        string reflection = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            writer.WriteLine(reflection);
            writer.WriteLine("--------------------------------------------------");
        }

        Console.WriteLine("Your reflection has been saved successfully.");
    }
}