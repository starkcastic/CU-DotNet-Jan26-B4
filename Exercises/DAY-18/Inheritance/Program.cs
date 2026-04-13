class Employee
{
    public int EmployeeId{ get; set; }
    public string EmployeeName { get; set; }

    public decimal BasicSalary { get; set; }
    public int ExperienceInYears { get; set; }

    public Employee(int id, string name, decimal basic, int exp)
    {
        EmployeeId = id;
        EmployeeName = name;
        BasicSalary = basic;
        ExperienceInYears = exp;
    }

    public decimal CalculateAnnualSalary()
    {
        return BasicSalary*12;
    }

    public override string ToString()
    {
        return $"EmployeeId = {EmployeeId}  EmployeeName = {EmployeeName}  BasicSalary = {BasicSalary} ExperienceInYears = {ExperienceInYears} AnnualSalary = {CalculateAnnualSalary()}";
    }
}

class PermanentEmployee : Employee
{
    public PermanentEmployee(int id, string name, decimal basic, int exp)
        : base(id, name, basic, exp) { }


    public new decimal CalculateAnnualSalary()
    {
        decimal amt = 0.0m;
        amt += (20*BasicSalary)/100;
        amt += (10*BasicSalary)/100;

        amt += (ExperienceInYears >= 5) ? 50.000m : 0.0m;

        amt += (12 * BasicSalary);

        return amt;
    }
}


class ContractEmployee : Employee
{
    public int ContractDurationInMonths { get; set; }

    public ContractEmployee(int id, string name, decimal basic, int exp, int duration)
        : base(id, name, basic, exp)
    {
        ContractDurationInMonths = duration;
    }

    public new decimal CalculateAnnualSalary()
    {
        decimal bonus = ContractDurationInMonths >= 12 ? 30000m : 0m;
        return (BasicSalary * 12) + bonus;
    }
}

class InternEmployee : Employee
{
    public InternEmployee(int id, string name, decimal basic, int exp)
        : base(id, name, basic, exp) { }

    public new decimal CalculateAnnualSalary()
    {
        return BasicSalary * 12;
    }
}

class Program
{
    static void Main()
    {
        Employee e1 = new Employee(1, "Ravi", 30000, 2);
        System.Console.WriteLine(e1.CalculateAnnualSalary());

        Employee e2 = new PermanentEmployee(2, "Amit", 40000, 6);
        PermanentEmployee p1 = new PermanentEmployee(3, "Rahul", 40000, 6);
        System.Console.WriteLine(e2.CalculateAnnualSalary());
        System.Console.WriteLine(p1.CalculateAnnualSalary());

        Employee e3 = new ContractEmployee(4, "Neha", 35000, 3, 14);
        ContractEmployee c1 = new ContractEmployee(5 , "Virat" , 50000, 4 , 13);
        System.Console.WriteLine(e3.CalculateAnnualSalary());
        System.Console.WriteLine(c1.CalculateAnnualSalary());


        Employee e4 = new InternEmployee(4, "Kiran", 15000, 0);
        InternEmployee i1 = new InternEmployee(5 , "Rohit" , 50000 , 0);
        System.Console.WriteLine(e4.CalculateAnnualSalary());
        System.Console.WriteLine(i1.CalculateAnnualSalary());

    }
}
