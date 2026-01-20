using System;

class GymMembership
{
    static void Main()
    {
        Console.WriteLine("Select Gym Services:");
        Console.Write("Do you want Treadmill service? (y/n): ");
        bool treadmill = Console.ReadLine().ToLower() == "y";

        Console.Write("Do you want Weight Lifting service? (y/n): ");
        bool weightLifting = Console.ReadLine().ToLower() == "y";

        Console.Write("Do you want Zumba Class? (y/n): ");
        bool zumba = Console.ReadLine().ToLower() == "y";

        double amount = CalculateMembershipAmount(treadmill, weightLifting, zumba);
        
        Console.WriteLine("\nTotal Monthly Membership Amount (including 5% GST): ₹" + amount);
    }

    static double CalculateMembershipAmount(bool treadmill, bool weightLifting, bool zumba)
    {
        if (!treadmill && !weightLifting && !zumba)
        {
            Console.WriteLine("At least one service must be selected.");
            return 200.00 + (double)(200 * 0.05);
        }

        double total = 1000; 

        if (treadmill)
            total += 300;

        if (weightLifting)
            total += 500;

        if (zumba)
            total += 250;

        double gst = total * 0.05;
        total += gst;

        return total;
    }
}
