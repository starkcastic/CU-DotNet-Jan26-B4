class Flight : IComparable<Flight>{
    public string FlightNumber { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime DepartureTime { get; set; }


    public Flight(string fno , decimal pri , TimeSpan dur , DateTime dt){
        FlightNumber = fno;
        Price = pri;
        Duration = dur;
        DepartureTime = dt;
    }

    public override string ToString()
    {
        return $"{FlightNumber,-6} | ₹{Price,-6} | {Duration} | {DepartureTime:t}";
    }

    public int CompareTo(Flight? other){
        return this.Price.CompareTo(other?.Price);
    }
}

class DurationComparer : IComparer<Flight>{
    public int Compare(Flight? a , Flight? b){
        return a.Duration.CompareTo(b?.Duration);
    }
}

class DepartureComparer : IComparer<Flight>{
    public int Compare(Flight? a , Flight? b){
        return a.DepartureTime.CompareTo(b?.DepartureTime);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Flight> flights = new List<Flight>{
            new Flight("AI101", 5000, TimeSpan.FromHours(2), DateTime.Now),
            new Flight("AI102", 3000, TimeSpan.FromHours(1.5), DateTime.Now),
            new Flight("AI103", 7000, TimeSpan.FromHours(1), DateTime.Now)
        };

        flights.Sort();
        foreach(var f in flights){
            Console.WriteLine(f);
        }
        System.Console.WriteLine();

        flights.Sort(new DurationComparer());
        foreach(var f in flights){
            Console.WriteLine(f);
        }
        System.Console.WriteLine();

        flights.Sort(new DepartureComparer());
        foreach(var f in flights){
            Console.WriteLine(f);
        }
        System.Console.WriteLine();
    }
}