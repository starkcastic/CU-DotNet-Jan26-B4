using System;
using GreetingLibrary;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your name:");
        string? name = Console.ReadLine();

        string greeting = GreetingHelper.GetGreeting(name ?? "");
        Console.WriteLine(greeting);
    }
}
