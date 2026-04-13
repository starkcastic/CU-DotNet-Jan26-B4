using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Subscriber : IComparable<Subscriber>
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public DateTime JoinDate { get; set; }

    protected Subscriber(Guid id, string name, DateTime joinDate)
    {
        ID = id;
        Name = name;
        JoinDate = joinDate;
    }

    public abstract decimal CalculateMonthlyBill();

    public override bool Equals(object obj)
    {
        if (obj is Subscriber other)
            return ID.Equals(other.ID);
        return false;
    }

    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }

    public int CompareTo(Subscriber other)
    {
        int dateCompare = JoinDate.CompareTo(other.JoinDate);
        if (dateCompare != 0) return dateCompare;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}

class BusinessSubscriber : Subscriber
{
    public decimal FixedRate { get; set; }
    public decimal TaxRate { get; set; }

    public BusinessSubscriber(Guid id, string name, DateTime joinDate, decimal fixedRate, decimal taxRate)
        : base(id, name, joinDate)
    {
        FixedRate = fixedRate;
        TaxRate = taxRate;
    }

    public override decimal CalculateMonthlyBill()
    {
        return FixedRate * (1 + TaxRate);
    }
}

class ConsumerSubscriber : Subscriber
{
    public decimal DataUsageGB { get; set; }
    public decimal PricePerGB { get; set; }

    public ConsumerSubscriber(Guid id, string name, DateTime joinDate, decimal dataUsageGB, decimal pricePerGB)
        : base(id, name, joinDate)
    {
        DataUsageGB = dataUsageGB;
        PricePerGB = pricePerGB;
    }

    public override decimal CalculateMonthlyBill()
    {
        return DataUsageGB * PricePerGB;
    }
}

class ReportGenerator
{
    public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
    {
        var sb = new StringBuilder();
        sb.AppendLine("----------------------------------------------------");
        sb.AppendLine("Name\t\tType\t\tMonthly Bill");
        sb.AppendLine("----------------------------------------------------");

        foreach (var sub in subscribers)
        {
            string type = sub is BusinessSubscriber ? "Business" : "Consumer";
            sb.AppendLine($"{sub.Name}\t\t{type}\t\t{sub.CalculateMonthlyBill():0.00}");
        }

        sb.AppendLine("----------------------------------------------------");
        Console.WriteLine(sb.ToString());
    }
}

class Program
{
    static void Main()
    {
        var dict = new Dictionary<string, Subscriber>();

        dict["virat@corp.com"] = new BusinessSubscriber(Guid.NewGuid(), "Virat", DateTime.Now.AddDays(-10), 1000, 0.18m);
        dict["rohit@corp.com"] = new BusinessSubscriber(Guid.NewGuid(), "Rohit", DateTime.Now.AddDays(-20), 1500, 0.15m);
        dict["dhoni@gmail.com"] = new ConsumerSubscriber(Guid.NewGuid(), "Dhoni", DateTime.Now.AddDays(-5), 50, 10);
        dict["hardik@gmail.com"] = new ConsumerSubscriber(Guid.NewGuid(), "Hardik", DateTime.Now.AddDays(-15), 70, 8);
        dict["bumrah@corp.com"] = new BusinessSubscriber(Guid.NewGuid(), "Bumrah", DateTime.Now.AddDays(-12), 1200, 0.2m);

        var sorted = dict.Values
            .OrderByDescending(s => s.CalculateMonthlyBill())
            .ToList();

        ReportGenerator.PrintRevenueReport(sorted);
    }
}