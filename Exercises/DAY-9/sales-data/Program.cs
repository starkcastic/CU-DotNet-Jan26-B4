using System; 
class Program
{
    static void Main(string[] args){
        int[] dailySales = new int[8];

        for(int i=1; i<dailySales.Length; i++)
        {
            Console.WriteLine($"Enter sales for day {i} : ");
            int x = int.Parse(Console.ReadLine());

            while(x < 0)
            {
                Console.WriteLine("Invalid input enter again");
                Console.WriteLine($"Enter sales for day {i} : ");
                x = int.Parse(Console.ReadLine());
            }

            dailySales[i] = x;
        }


        int totalSale = 0;

        for(int i=1; i<dailySales.Length; i++)
        {
            totalSale += dailySales[i];
        }

        float avgSale = (float)totalSale/7;

        int highSaleAmt = 0;
        int highSaleDay = 0;

        for(int i=1; i<dailySales.Length; i++)
        {
            if(dailySales[i] > highSaleAmt)
            {
                highSaleDay = i;
                highSaleAmt = dailySales[i];
            }
        }

        int lowSaleAmt = int.MaxValue;
        int lowSaleDay = 0;

        for(int i=1; i<dailySales.Length; i++)
        {
            if(dailySales[i] < lowSaleAmt)
            {
                lowSaleDay = i;
                lowSaleAmt = dailySales[i];
            }
        }

        int dayAvgSale = 0;

        for(int i=1; i<dailySales.Length; i++)
        {
            if(dailySales[i] > avgSale)
            {
                dayAvgSale++;
            }
        }

        string[] salesCategory = new string[8];

        for(int i=1; i<dailySales.Length; i++)
        {
            if(dailySales[i] < 5000)
                salesCategory[i] = "Low";
            else if(dailySales[i] > 15000)
                salesCategory[i] = "High";
            else
                salesCategory[i] = "Medium";
        }

        Console.WriteLine("Weekly Sales Report");
        Console.WriteLine("-------------------");
        Console.WriteLine($"Total Sales        : {totalSale}");
        Console.WriteLine($"Average Daily Sale : {avgSale}");
        Console.WriteLine($"Highest Sale       : {highSaleAmt}(Day {highSaleDay})");
        Console.WriteLine($"Lowest Sale        : {lowSaleDay}(Day {lowSaleDay})");
        Console.WriteLine($"Days Above Average : {dayAvgSale}");
        for(int i=1; i<salesCategory.Length; i++)
        {
            Console.WriteLine($"Day {i} : {salesCategory[i]}");
        }
    }
}