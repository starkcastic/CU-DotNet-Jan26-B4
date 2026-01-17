class Program
{
    static void Main(string[] args)
    {
        string[] policyHolderNames = new string[5];
        double[] annualPremiums = new double[5];

        for(int i=0; i<5; i++){
            System.Console.WriteLine("Enter name and amount : ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            while(parts.Length != 2 || parts[0].Length == 0 || double.Parse(parts[1]) <= 0)
            {
                Console.WriteLine("Oops you have entered something wrong");
                System.Console.WriteLine("Enter name and amount : ");
                input = Console.ReadLine();
                parts = input.Split(' ');
            }

            policyHolderNames[i] = parts[0];
            annualPremiums[i] = double.Parse(parts[1]);
        }

        double totalPre = 0;
        for(int i=0; i<annualPremiums.Length; i++){
            totalPre += annualPremiums[i];
        }

        double avgPre = totalPre/5;
        double highPre = annualPremiums.Max();
        double lowPre = annualPremiums.Min();


        Console.WriteLine("Insurance Premium Summary");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"{"Name",-15}{"Premium",15}{"Category",15}");
        Console.WriteLine("-----------------------------------------------");

        for (int i = 0; i < annualPremiums.Length; i++)
        {
            string cat;

            if (annualPremiums[i] < 10000)
                cat = "LOW";
            else if (annualPremiums[i] > 25000)
                cat = "HIGH";
            else
                cat = "MEDIUM";

            Console.WriteLine($"{policyHolderNames[i],-15}{annualPremiums[i],15:0.00}{cat,15}");
        }

        Console.WriteLine();
        Console.WriteLine($"{"Total Premium",-20}: {totalPre:C2}");
        Console.WriteLine($"{"Average Premium",-20}: {avgPre:C2}");
        Console.WriteLine($"{"Highest Premium",-20}: {highPre:C2}");
        Console.WriteLine($"{"Lowest Premium",-20}: {lowPre:C2}");

    }

}