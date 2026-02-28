using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter 4-digit PIN: ");

        string pin = "";
        int count = 0;

        while (count < 4)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (char.IsDigit(keyInfo.KeyChar))
            {
                pin += keyInfo.KeyChar;
                Console.Write("*");
                count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("PIN Entered: " + pin);

        Console.WriteLine("\nEnter System Message:");
        StringBuilder buffer = new StringBuilder();
        buffer.Append(Console.ReadLine());

        Console.WriteLine("System Message: " + buffer.ToString());
    }
}