using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    public T Data { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T data)
    {
        Data = data;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> child)
    {
        Children.Add(child);
    }
}

public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public override string ToString()
    {
        return $"{Name} ({Position})";
    }
}

public class OrganizationTree
{
    public TreeNode<Employee> Root { get; set; }

    public OrganizationTree(TreeNode<Employee> root)
    {
        Root = root;
    }

    public void DisplayHierarchy()
    {
        if (Root == null) return;

        Console.WriteLine("ORGANIZATION STRUCTURE");
        Console.WriteLine("======================");
        PrintRecursive(Root, 0);
    }

    private void PrintRecursive(TreeNode<Employee> current, int depth)
    {
        string indent = new string(' ', depth * 4);
        Console.WriteLine($"{indent}{current.Data}");

        foreach (var child in current.Children)
        {
            PrintRecursive(child, depth + 1);
        }
    }
}

class Program
{
    static void Main()
    {
        var ceo = new TreeNode<Employee>(new Employee("Aman", "CEO"));
        var director = new TreeNode<Employee>(new Employee("Suresh", "Director"));
        var manager = new TreeNode<Employee>(new Employee("Sonia", "Manager"));
        var seniorDev = new TreeNode<Employee>(new Employee("Sara", "Senior Dev"));
        var juniorDev = new TreeNode<Employee>(new Employee("Divakar", "Junior Dev"));
        var hrHead = new TreeNode<Employee>(new Employee("Rajesh", "HR Head"));
        var recruiter = new TreeNode<Employee>(new Employee("Rajat", "Recruiter"));

        ceo.AddChild(director);
        director.AddChild(manager);
        manager.AddChild(seniorDev);
        manager.AddChild(juniorDev);

        ceo.AddChild(hrHead);
        hrHead.AddChild(recruiter);

        var company = new OrganizationTree(ceo);

        company.DisplayHierarchy();

        Console.ReadKey();
    }
}