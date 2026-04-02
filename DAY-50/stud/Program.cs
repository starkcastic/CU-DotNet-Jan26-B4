using System;
using System.Collections.Generic;

class Student
{
    public string StudId { get; set; }
    public string SName { get; set; }

    public Student(string id, string name)
    {
        StudId = id;
        SName = name;
    }

    public override bool Equals(object obj)
    {
        if (obj is Student other)
            return StudId == other.StudId;
        return false;
    }

    public override int GetHashCode()
    {
        return StudId.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Dictionary<Student, int> records = new Dictionary<Student, int>();

        AddOrUpdate(records, new Student("S1", "Virat"), 80);
        AddOrUpdate(records, new Student("S2", "Rohit"), 75);
        AddOrUpdate(records, new Student("S1", "Virat"), 85);
        AddOrUpdate(records, new Student("S3", "Dhoni"), 90);

        foreach (var kv in records)
        {
            Console.WriteLine($"{kv.Key.StudId} {kv.Key.SName} {kv.Value}");
        }
    }

    static void AddOrUpdate(Dictionary<Student, int> records, Student student, int marks)
    {
        if (records.ContainsKey(student))
        {
            if (marks > records[student])
                records[student] = marks;
        }
        else
        {
            records[student] = marks;
        }
    }
}