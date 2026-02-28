using System;
using System.Collections.Generic;

public abstract class Appliance
{
    public string ModelName { get; set; }
    public int PowerConsumption { get; set; }

    public Appliance(string modelName, int power)
    {
        ModelName = modelName;
        PowerConsumption = power;
    }

    public abstract void Cook();

    public virtual void Preheat()
    {
        Console.WriteLine($"{ModelName}: No preheating required.");
    }
}

public interface ITimer
{
    void SetTimer(int minutes);
}

public interface IWifiEnabled
{
    void ConnectWifi();
}

public class Microwave : Appliance, ITimer
{
    public Microwave(string modelName, int power) : base(modelName, power) { }

    public override void Cook()
    {
        Console.WriteLine($"{ModelName}: Heating food quickly using microwave radiation.");
    }

    public void SetTimer(int minutes)
    {
        Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
    }
}

public class ElectricOven : Appliance, ITimer, IWifiEnabled
{
    public ElectricOven(string modelName, int power) : base(modelName, power) { }

    public override void Preheat()
    {
        Console.WriteLine($"{ModelName}: Preheating to required temperature...");
    }

    public override void Cook()
    {
        Preheat();
        Console.WriteLine($"{ModelName}: Baking food evenly with convection heat.");
    }

    public void SetTimer(int minutes)
    {
        Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
    }

    public void ConnectWifi()
    {
        Console.WriteLine($"{ModelName}: Connected to WiFi for remote monitoring.");
    }
}

public class AirFryer : Appliance
{
    public AirFryer(string modelName, int power) : base(modelName, power) { }

    public override void Cook()
    {
        Console.WriteLine($"{ModelName}: Cooking food quickly using hot air circulation.");
    }
}

public class Program
{
    public static void Main()
    {
        List<Appliance> kitchenDevices = new List<Appliance>
        {
            new Microwave("QuickHeat 2000", 1200),
            new ElectricOven("AeroCook Pro", 2400),
            new AirFryer("AirCrisp Lite", 1500)
        };

        Console.WriteLine("=== Cooking Process ===");
        foreach (var device in kitchenDevices)
        {
            device.Cook();
            Console.WriteLine();
        }

        Console.WriteLine("=== WiFi Capability Check ===");
        foreach (var device in kitchenDevices)
        {
            if (device is IWifiEnabled wifiDevice)
            {
                wifiDevice.ConnectWifi();
            }
            else
            {
                Console.WriteLine($"{device.ModelName}: No WiFi capability.");
            }
        }
    }
}