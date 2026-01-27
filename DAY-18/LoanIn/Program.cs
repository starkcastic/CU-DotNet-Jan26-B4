class Loan
{
    public string LoanNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal PrincipalAmount { get; set; }
    public int TenureInYears { get; set; }

    public Loan()
    {
        LoanNumber = string.Empty;
        CustomerName = string.Empty;
        PrincipalAmount = 0.0m;
        TenureInYears = 0;
    }

    public Loan(string loannumber , string customername , decimal principalamount , int tenureinyears)
    {
        LoanNumber = loannumber;
        CustomerName = customername;
        PrincipalAmount = principalamount;
        TenureInYears = tenureinyears;
    }

    public double CalculateEMI()
    {
        double amt = ((double)PrincipalAmount*10*TenureInYears)/(double)100;
        amt += (double)PrincipalAmount;

        return amt/TenureInYears;
    }
}

class HomeLoan : Loan
{   
    public HomeLoan(string loannumber , string customername , decimal principalamount , int tenureinyears) : base(loannumber , customername , principalamount ,tenureinyears)
    {
        
    }
    public new double CalculateEMI()
    {
        double amt = ((double)PrincipalAmount*8*TenureInYears)/(double)100;
        amt += (double)PrincipalAmount;
        amt += (1*(double)PrincipalAmount)/(double)100;

        return amt/TenureInYears;
    }
}

class CarLoan : Loan
{
    public CarLoan(string loannumber , string customername , decimal principalamount , int tenureinyears) : base(loannumber , customername , principalamount ,tenureinyears)
    {
        
    }
    public new double CalculateEMI()
    {
        double amt = ((double)PrincipalAmount*9*TenureInYears)/(double)100;
        amt += (double)PrincipalAmount;
        amt += 15000;

        return amt/TenureInYears;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // HomeLoan h1 = new HomeLoan("1" , "nishanth1" , 1000 , 10);
        // HomeLoan h2 = new HomeLoan("2" , "nishanth2" , 1000 , 10);

        // CarLoan c1 = new CarLoan("3" , "nishantc1" , 1000 , 10);
        // CarLoan c2 = new CarLoan("4" , "nishantc2" , 1000 , 10);

        Loan[] loans = new Loan[4]
        {
            new HomeLoan("1" , "nishanth1" , 1000 , 10),
            new HomeLoan("2" , "nishanth2" , 1000 , 10),
            new CarLoan("3" , "nishantc1" , 1000 , 10),
            new CarLoan("4" , "nishantc2" , 1000 , 10)
        };
        // loans[0] = h1;
        // loans[1] = h2;
        // loans[2] = c1;
        // loans[3] = c2;

        for(int i=0; i<4; i++)
        {
            System.Console.WriteLine(loans[i].CalculateEMI());
        }
        
    }
}