using System;

class Program
{
    static void Main()
    {
        string trarec = Console.ReadLine();

        trarec = trarec.Trim();

        string id = "";

        for(int i=0; i<trarec.Length; i++)
        {
            if(trarec[i] != '#')
                id += trarec[i];
            else
                break;
        }

        string name = "";
        int pos = trarec.IndexOf('#');
        pos++;

        for(int i=pos; i<trarec.Length; i++)
        {
            if(trarec[i] != '#')
                name += trarec[i];
            else
                break;
        }

        string tranar = "";

        pos = trarec.IndexOf('#');
        pos++;
        pos = trarec.IndexOf('#' , pos);
        pos++;

        for(int i=pos; i<trarec.Length; i++)
        {
            if(trarec[i] == ' ' && tranar == "")
                continue;
            else if(tranar.Length > 0 && trarec[i] == ' ' && tranar[tranar.Length-1] == ' ')
                continue;
            else
                tranar += trarec[i];
        }

        // System.Console.WriteLine(id);
        // System.Console.WriteLine(name);
        // System.Console.WriteLine(tranar);
        tranar = tranar.ToLower();
        string stnar = "cash deposit successful";

        string [] words = {"deposit" , "withdrawal" , "transfer"};

        int flg = -1;
        for(int i=0; i<words.Length; i++)
        {
            flg = tranar.IndexOf(words[i]);
            if(flg != -1)
                break;
        }  

        string cat = "";

        if(flg == -1)
        {
            cat = "NON-FINANCIAL TRANSACTION";   
        }else if(stnar == tranar)
        {
            cat = "STANDARD TRANSACTION";
        }
        else
        {
            cat = "CUSTOM TRANSACTION";
        }

        Console.WriteLine($"Transaction ID  : {id}");
        Console.WriteLine($"Account Holder  : {name}");
        Console.WriteLine($"Narration       : {tranar}");
        Console.WriteLine($"Category        : {cat}");
    }
}
