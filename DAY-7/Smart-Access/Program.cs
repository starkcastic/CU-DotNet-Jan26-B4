using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter login ID : ");
        string loginId = Console.ReadLine();

        if(loginId == ""){
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        string[] str = loginId.Split('|');

        if(str.Length != 5){
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        string temp = str[0];

        if(temp.Length != 2 || temp[0] > 'Z' || temp[0] < 'A' || temp[1] > '9' || temp[1] < '0'){
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        temp = str[1];

        if(temp.Length != 1 || temp[0] > 'Z' || temp[0] < 'A'){
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        temp = str[2];

        if(temp.Length != 1 || temp[0] > '7' || temp[0] < '1'){
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        temp = str[3];
        temp = temp.ToLower();

        if(temp == "true" || temp == "false"){

        }else{
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        if(byte.Parse(str[4]) > 200 || byte.Parse(str[4]) < 0){
            System.Console.WriteLine("INVALID ACCESS LOG");
            return;
        }


// --------------------------------------------------------------------------------------------------------

        string gate = str[0];
        char user = str[1][0];
        byte level = byte.Parse(str[2]);
        byte attempts = byte.Parse(str[4]);

        string status = "";

        if(str[3].ToLower() == "false"){
            Console.WriteLine("ACCESS DENIED – INACTIVE USER");
            return;
        }else if(attempts > 100){
            Console.WriteLine("ACCESS DENIED – TOO MANY ATTEMPTS");
            return;
        }else if(level > 5){
            status = "ACCESS GRANTED – HIGH SECURITY";
        }else{
            status = "ACCESS GRANTED – STANDARD";
        }

        Console.WriteLine($"{"Gate".PadRight(10)}: {gate}");
        Console.WriteLine($"{"User".PadRight(10)}: {user}");
        Console.WriteLine($"{"Level".PadRight(10)}: {level}");
        Console.WriteLine($"{"Attempts".PadRight(10)}: {attempts}");
        Console.WriteLine($"{"Status".PadRight(10)}: {status}");
    }
}