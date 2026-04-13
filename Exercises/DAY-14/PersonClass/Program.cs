class Employee
{
    private int id;
    
    public void setID(int id)
    {
        this.id = id;
    }

    public void getID()
    {
        System.Console.WriteLine(id);
    }

    public string name { get; set; } = string.Empty;
    
    private string department = string.Empty;
    public string DEPARTMENT
    {
        get { return department; }
        set { 
            if (value == "Accounts" || value == "Sales" || value == "IT")
                department = value;
            else
                Console.WriteLine("Invalid Department");
        }
    }
    
    private int salary;
    public int SALARY
    {
        get { return salary; }
        set { 
            if(value >= 50000 && value <= 90000)
                salary = value;
            else
                Console.WriteLine("Salary must be between 50000 and 90000");

        }
    }

   public void Display()
    {
        Console.WriteLine("Id: " + id);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Department: " + department);
        Console.WriteLine("Salary: " + salary);
    }
}

class Program
{   
    static void Main(string[] args)
    {
        Employee e1 = new Employee();
        e1.setID(10430);
        e1.name = "Nishant";
        e1.DEPARTMENT = "IT";
        e1.SALARY = 90000;
        e1.Display();
    }
}
