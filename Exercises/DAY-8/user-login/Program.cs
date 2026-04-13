using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] parts = input.Split('|');

        string userName = parts[0];
        string loginMessage = parts[1];

        string cleanedMessage = loginMessage.Trim().ToLower();

        string standardMessage = "login successful";

        string status;

        if (!cleanedMessage.Contains("successful"))
        {
            status = "LOGIN FAILED";
        }
        else if (cleanedMessage.Equals(standardMessage))
        {
            status = "LOGIN SUCCESS";
        }
        else
        {
            status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
        }

        Console.WriteLine($"User     : {userName}");
        Console.WriteLine($"Message  : {cleanedMessage}");
        Console.WriteLine($"Status   : {status}");
    }
}
