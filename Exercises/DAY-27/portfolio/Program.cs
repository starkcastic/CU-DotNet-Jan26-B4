using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class Loan
{
    public string ClientName { get; set; }
    public double Principal { get; set; }
    public double InterestRate { get; set; }
}

public class Program
{
    static void Main()
    {
        string filePath = "loans.csv";

        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("ClientName,Principal,InterestRate");
            }
        }

        Console.Write("Enter Client Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Principal Amount: ");
        double principal;
        while (!double.TryParse(Console.ReadLine(), out principal))
        {
            Console.Write("Invalid amount. Enter Principal again: ");
        }

        Console.Write("Enter Interest Rate (%): ");
        double rate;
        while (!double.TryParse(Console.ReadLine(), out rate))
        {
            Console.Write("Invalid rate. Enter Interest Rate again: ");
        }

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{name},{principal},{rate}");
        }

        List<Loan> loans = new List<Loan>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length != 3)
                    continue;

                string clientName = parts[0];

                if (!double.TryParse(parts[1], out double filePrincipal))
                {
                    Console.WriteLine($"Invalid Principal for {clientName}. Skipping record.");
                    continue;
                }

                if (!double.TryParse(parts[2], out double fileRate))
                {
                    Console.WriteLine($"Invalid Rate for {clientName}. Skipping record.");
                    continue;
                }

                loans.Add(new Loan
                {
                    ClientName = clientName,
                    Principal = filePrincipal,
                    InterestRate = fileRate
                });
            }
        }

        Console.WriteLine();
        Console.WriteLine("Loan Portfolio Summary");
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine($"{"Client",-15} {"Principal",12} {"Rate %",8} {"Interest",12} {"Risk Level",12}");
        Console.WriteLine("-------------------------------------------------------------");

        foreach (var loan in loans)
        {
            double interestAmount = loan.Principal * loan.InterestRate / 100;

            string riskLevel;
            if (loan.InterestRate > 10)
                riskLevel = "High Risk";
            else if (loan.InterestRate >= 5)
                riskLevel = "Medium Risk";
            else
                riskLevel = "Low Risk";

            Console.WriteLine(
                $"{loan.ClientName,-15} {loan.Principal,12:C} {loan.InterestRate,8:F2} {interestAmount,12:C} {riskLevel,12}");
        }
    }
}