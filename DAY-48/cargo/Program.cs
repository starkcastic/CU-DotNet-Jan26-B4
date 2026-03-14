class Item
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public string Category { get; set; }

    public Item(string nm , double wt , string cat)
    {
        Name = nm;
        Weight = wt;
        Category = cat;
    }
}

class Container
{
    public string ContainerId { get; set; }
    public List<Item> Items { get; set; }

    public Container(string id , List<Item>li)
    {
        ContainerId = id;
        Items = li;
    }
}

public class CargoManifestOptimizer
{
    private List<List<Container>> cargoBay;

    public CargoManifestOptimizer(List<List<Container>> cargoBay)
    {
        this.cargoBay = cargoBay;
    }

    public List<string>  FindHeavyContainers(double weightThreshold)
    {
        List<string>result = new List<string>();

        foreach(var row in cargoBay)
        {
            if(row == null)
                continue;
            foreach(var container in row)
            {
                if (container == null || container.Items == null)
                    continue;

                double totalWeight = 0;

                foreach(var item in container.Items)
                {
                    if(item != null)
                        totalWeight += item.Weight;
                }

                if(totalWeight > weightThreshold)
                    result.Add(container.ContainerId); 
            }
        }
        return result;
    }

    public Dictionary<string, int> GetItemCountsByCategory()
    {
        Dictionary<string , int> result = new Dictionary<string, int>();

        foreach(var row in cargoBay)
        {
            if(row == null)
                continue;
            foreach(var container in row)
            {
                if(container == null || container.Items == null)
                    continue;
                
                foreach(var item in container.Items)
                {
                    if(item != null)
                    {
                        if (result.ContainsKey(item.Category))
                        {
                            result[item.Category] += 1;
                        }
                        else
                        {
                            result.Add(item.Category , 1);
                        }
                    }
                }
            }
        }
        return result;
    }

    public List<Item> FlattenAndSortShipment()
    {
        return cargoBay
            .Where(row => row != null)
            .SelectMany(row => row)
            .Where(container => container?.Items != null)
            .SelectMany(container => container.Items)
            .GroupBy(item => item.Name) 
            .Select(g => g.First())
            .OrderBy(item => item.Category)
            .ThenByDescending(item => item.Weight)
            .ToList();
    }

}

class Program
{
    static void Main(string[] args)
    {
        var cargoBay = new List<List<Container>>
        {
            new List<Container> 
            { 
                new Container("C001", new List<Item> 
                { 
                    new Item("Laptop", 2.5, "Tech"), 
                    new Item("Monitor", 5.0, "Tech"),
                    new Item("Smartphone", 0.5, "Tech")
                }),
                new Container("C104", new List<Item>
                {
                    new Item("Server Rack", 45.0, "Tech"), 
                    new Item("Cables", 1.2, "Tech")
                })
            },

            new List<Container> 
            { 
                new Container("C002", new List<Item> 
                { 
                    new Item("Apple", 0.2, "Food"),
                    new Item("Banana", 0.2, "Food"),
                    new Item("Milk", 1.0, "Food")
                }),
                new Container("C003", new List<Item> 
                { 
                    new Item("Table", 15.0, "Furniture"),
                    new Item("Chair", 7.5, "Furniture")
                })
            },	

            new List<Container>
            {
                new Container("C205", new List<Item> 
                { 
                    new Item("Vase", 3.0, "Decor"),
                    new Item("Mirror", 12.0, "Decor")
                }),
                new Container("C206", new List<Item>()) 
            },

            new List<Container>() 
        };

        var optimizer = new CargoManifestOptimizer(cargoBay);

        Console.WriteLine("Heavy Containers (>20 weight):");
        var heavy = optimizer.FindHeavyContainers(20);

        foreach (var id in heavy)
        {
            Console.WriteLine(id);
        }

        Console.WriteLine();

        Console.WriteLine("Item Counts By Category:");
        var categoryCounts = optimizer.GetItemCountsByCategory();

        foreach (var pair in categoryCounts)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }

        Console.WriteLine();

        Console.WriteLine("Flattened and Sorted Shipment:");
        var items = optimizer.FlattenAndSortShipment();

        foreach (var item in items)
        {
            Console.WriteLine($"{item.Category} - {item.Name} ({item.Weight})");
        }
    }
}

