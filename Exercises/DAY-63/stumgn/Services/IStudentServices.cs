using stumgn.Models;
using stumgn.Repo;
using stumgn.Services;

namespace stumgn.Services
{
    public interface IStudentServices
    {
        public void AddStudent(Student student);

        public IEnumerable<Student> GetStudent();
        public void UpdateStudent(Student student);

        public void DeleteStudent(int id);

    }
}