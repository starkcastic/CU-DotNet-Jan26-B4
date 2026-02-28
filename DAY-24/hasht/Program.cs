using System;
using System.Collections;

public class Program
{
    public static void Main()
    {
        Hashtable employeeTable = new Hashtable();

        employeeTable.Add(101, "Alice");
        employeeTable.Add(102, "Bob");
        employeeTable.Add(103, "Charlie");
        employeeTable.Add(104, "Diana");

        if (!employeeTable.ContainsKey(105))
        {
            employeeTable.Add(105, "Edward");
        }
        else
        {
            Console.WriteLine("ID already exists.");
        }

        string employeeName = (string)employeeTable[102];
        Console.WriteLine("Employee 102 Name: " + employeeName);

        foreach (DictionaryEntry entry in employeeTable)
        {
            Console.WriteLine("ID: " + entry.Key + ", Name: " + entry.Value);
        }

        employeeTable.Remove(103);

        Console.WriteLine("Total Employees: " + employeeTable.Count);
    }
}