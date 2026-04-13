class Program
{
    static void Main(string[] args)
    {
        PrintLine();            
        PrintLine('+');     
        PrintLine('$', 60);    
    }

    static void PrintLine(char ch = '-', int count = 40){
        for (int i = 0; i < count; i++){
            Console.Write(ch);
        }
        Console.WriteLine();
    }
}