using System;
using System.Collections.Generic;
using System.Linq;

public class Ride
{
    public string RideID { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public decimal Fare { get; set; }

    public Ride(string rideID, string from, string to, decimal fare)
    {
        RideID = rideID;
        From = from;
        To = to;
        Fare = fare;
    }
}

public class OLADriver
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string VehicleNo { get; set; }
    public List<Ride> Rides { get; set; }

    public OLADriver(int id, string name, string vehicleNo)
    {
        Id = id;
        Name = name;
        VehicleNo = vehicleNo;
        Rides = new List<Ride>();
    }

    public void AddRide(Ride ride)
    {
        Rides.Add(ride);
    }

    public decimal GetTotalFare()
    {
        return Rides.Sum(r => r.Fare);
    }
}

public class Program
{
    public static void Main()
    {
        List<OLADriver> drivers = new List<OLADriver>();

        OLADriver driver1 = new OLADriver(1, "Rohit Sharma", "PB10AB1234");
        driver1.AddRide(new Ride("R101", "Chandigarh", "Mohali", 250m));
        driver1.AddRide(new Ride("R102", "Mohali", "Kharar", 180m));

        OLADriver driver2 = new OLADriver(2, "Virat Kohli", "PB10CD5678");
        driver2.AddRide(new Ride("R201", "Delhi", "Gurgaon", 320m));
        driver2.AddRide(new Ride("R202", "Gurgaon", "Noida", 410m));
        driver2.AddRide(new Ride("R203", "Noida", "Delhi", 290m));

        drivers.Add(driver1);
        drivers.Add(driver2);

        foreach (var driver in drivers)
        {
            Console.WriteLine($"Driver ID: {driver.Id}");
            Console.WriteLine($"Name: {driver.Name}");
            Console.WriteLine($"Vehicle No: {driver.VehicleNo}");
            Console.WriteLine("Rides:");

            foreach (var ride in driver.Rides)
            {
                Console.WriteLine($"  RideID: {ride.RideID}, From: {ride.From}, To: {ride.To}, Fare: {ride.Fare}");
            }

            Console.WriteLine($"Total Fare: {driver.GetTotalFare()}");
            Console.WriteLine("-----------------------------------");
        }
    }
}