using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Participant
{
    public string Name { get; set; }
    public decimal Paid { get; set; }
    public decimal Balance { get; set; }
}

public class Transaction
{
    public string Payer { get; set; }
    public string Receiver { get; set; }
    public decimal Amount { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Participant> participants = new List<Participant>
        {
            new Participant { Name = "Aman", Paid = 900m },
            new Participant { Name = "Soman", Paid = 0m },
            new Participant { Name = "Kartik", Paid = 1290m }
        };

        decimal totalSpent = participants.Sum(p => p.Paid);
        decimal fairShare = totalSpent / participants.Count;

        foreach (var p in participants)
        {
            p.Balance = p.Paid - fairShare;
        }

        var creditors = participants
            .Where(p => p.Balance > 0)
            .OrderByDescending(p => p.Balance)
            .ToList();

        var debtors = participants
            .Where(p => p.Balance < 0)
            .OrderBy(p => p.Balance)
            .ToList();

        List<Transaction> transactions = new List<Transaction>();

        int i = 0, j = 0;

        while (i < debtors.Count && j < creditors.Count)
        {
            var debtor = debtors[i];
            var creditor = creditors[j];

            decimal amountToPay = Math.Min(-debtor.Balance, creditor.Balance);
            amountToPay = Math.Round(amountToPay, 2);

            transactions.Add(new Transaction
            {
                Payer = debtor.Name,
                Receiver = creditor.Name,
                Amount = amountToPay
            });

            debtor.Balance += amountToPay;
            creditor.Balance -= amountToPay;

            if (Math.Round(debtor.Balance, 2) == 0)
                i++;

            if (Math.Round(creditor.Balance, 2) == 0)
                j++;
        }

        string filePath = "settlements.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Payer,Receiver,Amount");

            foreach (var t in transactions)
            {
                writer.WriteLine($"{t.Payer},{t.Receiver},{t.Amount:F2}");
            }
        }

        Console.WriteLine("Settlement Complete.");
        Console.WriteLine("Fair Share per Person: " + fairShare.ToString("F2"));
        Console.WriteLine("Transactions:");

        foreach (var t in transactions)
        {
            Console.WriteLine($"{t.Payer} pays {t.Receiver} {t.Amount:F2}");
        }

        Console.WriteLine("CSV exported to settlements.csv");
    }
}