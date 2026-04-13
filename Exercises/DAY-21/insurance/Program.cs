using System;
using System.Collections.Generic;

public class Policy
{
    public string HolderName { get; set; }
    public decimal Premium { get; set; }
    public int RiskScore { get; set; }
    public DateTime RenewalDate { get; set; }

    public Policy(string holderName, decimal premium, int riskScore, DateTime renewalDate)
    {
        HolderName = holderName;
        Premium = premium;
        RiskScore = riskScore;
        RenewalDate = renewalDate;
    }

    public override string ToString()
    {
        return $"Holder: {HolderName}, Premium: {Premium}, RiskScore: {RiskScore}, RenewalDate: {RenewalDate.ToShortDateString()}";
    }
}

public class PolicyTracker
{
    private Dictionary<string, Policy> policies = new Dictionary<string, Policy>();

    public void AddPolicy(string id, Policy policy)
    {
        policies[id] = policy;
    }

    public void BulkAdjustment()
    {
        foreach (var kvp in policies)
        {
            if (kvp.Value.RiskScore > 75)
            {
                kvp.Value.Premium += kvp.Value.Premium * 0.05m;
            }
        }
    }

    public void CleanUp()
    {
        List<string> keysToRemove = new List<string>();
        DateTime threshold = DateTime.Now.AddYears(-3);

        foreach (var kvp in policies)
        {
            if (kvp.Value.RenewalDate < threshold)
            {
                keysToRemove.Add(kvp.Key);
            }
        }

        foreach (var key in keysToRemove)
        {
            policies.Remove(key);
        }
    }

    public string GetPolicy(string id)
    {
        if (policies.TryGetValue(id, out Policy policy))
        {
            return policy.ToString();
        }
        return "Policy Not Found";
    }
}

public class Program
{
    public static void Main()
    {
        PolicyTracker tracker = new PolicyTracker();

        tracker.AddPolicy("P101", new Policy("Rohit Sharma", 1000m, 80, DateTime.Now.AddYears(-1)));
        tracker.AddPolicy("P102", new Policy("Virat Kohli", 1500m, 60, DateTime.Now.AddYears(-4)));
        tracker.AddPolicy("P103", new Policy("Jasprit Bumrah", 2000m, 90, DateTime.Now.AddMonths(-6)));

        tracker.BulkAdjustment();
        tracker.CleanUp();

        Console.WriteLine(tracker.GetPolicy("P101"));
        Console.WriteLine(tracker.GetPolicy("P102"));
        Console.WriteLine(tracker.GetPolicy("P999"));
    }
}