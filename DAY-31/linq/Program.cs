class Student
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Div { get; set; }
    public int  Marks { get; set; }

    public Student(int id , string nm , string d , int marks)
    {
        Id = id;
        Name = nm;
        Div = d;
        Marks = marks;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student(1, "Virat", "A", 85),
            new Student(2, "Rohit", "B", 78),
            new Student(3, "Hardik", "A", 92),
            new Student(4, "Messi", "C", 67),
            new Student(5, "Ronaldo", "B", 88)
        };

        var top3 = students.OrderByDescending(x => x.Marks).Take(3);

        foreach(var val in top3)
        {
            System.Console.WriteLine($"{val.Name} - {val.Marks}");
        }

        var avgMa = students.GroupBy(x => x.Div).Select(g => new 
                                                        {
                                                            Division = g.Key ,
                                                            avgMarks = g.Average(s => s.Marks)
                                                        });
        foreach(var val in avgMa){
            System.Console.WriteLine($"{val.Division} - {val.avgMarks}");
        }

        
    }
}