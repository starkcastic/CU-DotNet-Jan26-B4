
class Patient
{
    public string Name { get; set; }
    public decimal BaseFee { get; set; }

    public Patient(string name, decimal baseFee){
        Name = name;
        BaseFee = baseFee;
    }

    public virtual decimal CalculateFinalBill(){
        return BaseFee;
    }
}

class Inpatient : Patient
{
    public int DaysStayed { get; set; } 
    public decimal DailyRate { get; set; }

    public Inpatient(string name, decimal baseFee, int daysStayed, decimal dailyRate)
        : base(name, baseFee){
        DaysStayed = daysStayed;
        DailyRate = dailyRate;
    }

    public override decimal CalculateFinalBill()
    {
        return base.CalculateFinalBill() + DailyRate * DaysStayed;
    }
}

class Outpatient : Patient
{
    public decimal ProcedureFee { get; set; }

    public Outpatient(string name, decimal baseFee, decimal procedureFee)
        : base(name, baseFee){
        ProcedureFee = procedureFee;
    }

    public override decimal CalculateFinalBill(){
        return base.CalculateFinalBill() + ProcedureFee;
    }
}

class EmergencyPatient : Patient{
    public int SeverityLevel { get; set; }

    public EmergencyPatient(string name, decimal baseFee, int severityLevel)
        : base(name, baseFee){
        SeverityLevel = severityLevel;
    }

    public override decimal CalculateFinalBill()
    {
        return base.CalculateFinalBill() * SeverityLevel;
    }
}

class HospitalBilling
{
    public List<Patient> Patients  = new List<Patient>();

    public void AddPatient(Patient p){
        Patients.Add(p);
    }

    public void GenerateDailyReport(){
        System.Console.WriteLine("Daily Report");

        foreach(var item in Patients)
        {
            System.Console.WriteLine(item.Name);
            decimal ti = item.CalculateFinalBill();
            System.Console.WriteLine(ti.ToString("C2"));
        }
    }

    public decimal CalculateTotalRevenue()
    {
        decimal ti = 0;
        foreach(var item in Patients){
            ti += item.CalculateFinalBill();
        }

        return ti;
    }

    public int GetInpatientCount()
    {
        int cnt = 0;

        foreach (var item in Patients){
            if(item is Inpatient)
                cnt++;
        }

        return cnt;
    }
}

class Program{
    static void Main(){
        HospitalBilling billing = new HospitalBilling();

        billing.AddPatient(new Inpatient("Ramesh", 2000m, 3, 1500m));
        billing.AddPatient(new Outpatient("Sita", 1000m, 2500m));
        billing.AddPatient(new EmergencyPatient("Arjun", 3000m, 4));

        System.Console.WriteLine();
        billing.GenerateDailyReport();

        Console.WriteLine("\nTotal Revenue: " +
            billing.CalculateTotalRevenue().ToString("C2"));

        Console.WriteLine("Total Inpatients: " +
            billing.GetInpatientCount());
    }
}
