using stumgn.Models;
using stumgn.Repo;
using stumgn.Services;

namespace stumgn.UI
{   public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("hello starkcastic");
            Console.WriteLine("Json or List (1/2)");
            var repoOption = int.Parse( Console.ReadLine());

            IStudentRepo repo = null;

            if(repoOption == 1){
                // repo = new JsonStudentRepo(); 
            }else{
                repo = new ListStudentRepo();  
            }

            IStudentServices service = new StudentServices(repo);

            while (true)
            {
                System.Console.WriteLine("\n1. Add\n2. View All\n3. Update\n4. Delete\n5. Exit");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                    {
                        System.Console.WriteLine("Enter id : ");
                        int id = int.Parse(Console.ReadLine());

                        System.Console.WriteLine("Enter name : ");
                        string name = Console.ReadLine();

                        System.Console.WriteLine("Enter grade : ");
                        int grade = int.Parse(Console.ReadLine());

                        Student student = new Student
                        {
                            Id = id,
                            Name = name,
                            Grade = grade
                        };
                        service.AddStudent(student);

                        break;
                    }
                    case "2":
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("The data entered till now is : ");
                        System.Console.WriteLine();
                        var students = service.GetStudent();

                        foreach(var x in students)
                        {
                            System.Console.WriteLine($"{x.Id} {x.Name} {x.Grade}");
                        }
                        break;
                    }
                    case "3":
                    {
                        System.Console.WriteLine("Enter id of user that you want to update : ");
                        int id = int.Parse(Console.ReadLine());

                        System.Console.WriteLine("Enter name : ");
                        string name = Console.ReadLine();

                        System.Console.WriteLine("Enter grade : ");
                        int grade = int.Parse(Console.ReadLine());

                        Student student = new Student
                        {
                            Id = id,
                            Name = name,
                            Grade = grade
                        };

                        service.UpdateStudent(student);
                        break;
                    }
                    case "4":
                    {
                        System.Console.WriteLine("Enter id of user that you want to delete : ");
                        int id = int.Parse(Console.ReadLine());

                        service.DeleteStudent(id);
                        break;
                    }
                    case "5":
                        return;
                }
            }

        }  
    }
}