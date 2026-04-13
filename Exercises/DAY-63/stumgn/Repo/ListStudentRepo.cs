using stumgn.Models;
using stumgn.Repo;
using stumgn.Services;

namespace stumgn.Repo
{
    public class ListStudentRepo : IStudentRepo
    {
        public static List<Student> students = new List<Student>();
        public void AddStudent(Student student)
        {
            // Console.WriteLine("Repo called");
            students.Add(student);

            // foreach(var x in students)
            // {
            //     System.Console.WriteLine(x.Id);
            //     System.Console.WriteLine(x.Name);
            //     System.Console.WriteLine(x.Grade);
            // }
        }

        public IEnumerable<Student> GetStudent()
        {
            return students;
        }

        public void UpdateStudent(Student student)
        {
            Student temp = null;

            foreach(var x in students)
            {
                if(x.Id == student.Id)
                {
                    temp = x;
                    break;
                }
            }

            students.Remove(temp);
            students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            Student temp = null;

            foreach(var x in students)
            {
                if(x.Id == id)
                {
                    temp = x;
                    break;
                }
            }

            students.Remove(temp);
        }
    }
}