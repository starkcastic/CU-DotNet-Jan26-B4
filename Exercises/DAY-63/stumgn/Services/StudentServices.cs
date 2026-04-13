using stumgn.Models;
using stumgn.Repo;
using stumgn.Services;

namespace stumgn.Services
{
    public class StudentServices : IStudentServices
    {   
        public readonly IStudentRepo _repo;

        public StudentServices(IStudentRepo repo)
        {
            _repo = repo;
        }

        public void AddStudent(Student student)
        {
            if(student.Grade < 1 || student.Grade > 100)
            {
                System.Console.WriteLine("game over ho gya bhai");
                return;
            }

            _repo.AddStudent(student);
        }

        public IEnumerable<Student> GetStudent()
        {
            return _repo.GetStudent();
        }

        public void UpdateStudent(Student student)
        {
            _repo.UpdateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _repo.DeleteStudent(id);
        }
    }
}