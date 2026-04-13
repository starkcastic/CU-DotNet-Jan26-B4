abstract class Vehicle
{
    public string ModelName { get; set; }

    public Vehicle(string modelName)
    {
        ModelName = modelName;
    }

    public abstract void Move();

    public virtual string GetFuelStatus()
    {
        return "Fuel level is stable.";
    }
}

class ElectricCar : Vehicle
{   
    public ElectricCar(string name) : base(name){}
    public override void Move()
    {
        Console.WriteLine($"{ModelName} is gliding silently on battery power");
    }

    public override string GetFuelStatus()
    {
        return $"{ModelName} battery is at 80%";
    }
}

class HeavyTruck : Vehicle
{
    public HeavyTruck(string name) : base(name){}
    public override void Move()
    {
        Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power");
    }
}

class CargoPlane : Vehicle
{
    public CargoPlane(string name) : base(name){}
    public override void Move()
    {
        Console.WriteLine($"{ModelName} is ascending to 30,000 feet");
    }

    public override string GetFuelStatus()
    {
        return base.GetFuelStatus() + $"Checking jet fuel reserves...";
    }
}

class FleetController
{
    static void Main(string[] args)
    {
        Vehicle[] vehicles = new Vehicle[]
        {
            new ElectricCar("Nexon"),
            new HeavyTruck("Ashok Leyland"),
            new CargoPlane("cargobhai")
        };


        for(int i=0; i<vehicles.Length; i++)
        {
            vehicles[i].Move();
            System.Console.WriteLine(vehicles[i].GetFuelStatus());
            System.Console.WriteLine();
        }
    }
}
