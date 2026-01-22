
class Height{
    private int feet;
    public int Feet{
        get { return feet; }
        set { feet = value; }
    }

    private decimal inches;
    public decimal Inches{
        get { return inches; }
        set { inches = value; }
    }

    public Height(){
        feet = 0;
        inches = 0.0m;
    }

    public Height(int feet , decimal inches){
        this.feet = feet;
        this.inches = inches;

        adjust();
    }

    public Height(decimal inches)
    {
        this.inches = inches;

        adjust();
    }

    public Height AddHeight(Height h2){
        decimal x = inches + h2.inches;
        int y = feet + h2.feet;

        while(x >= 12){
            y += 1;
            x -= 12;
        }

        Height h3 = new Height(y , x);
        adjust();

        return h3;
    }

    public void adjust(){
        if(Inches >= 12){
            int extraFeet = (int)(Inches / 12);
            Feet += extraFeet;
            Inches = Inches % 12;
        }
    }
    public override string ToString(){
        return $"Height - {feet} feet {inches} inches";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Height h1 = new Height(0 , 180m);
        Height h2 = new Height(180m);
        Height h3 = new Height();

        h3 = h1.AddHeight(h2);

        Console.WriteLine(h1);
        Console.WriteLine(h2);
        Console.WriteLine(h3);
    }
}