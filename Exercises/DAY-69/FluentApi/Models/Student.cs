using FluentApi.Models;

namespace FluentApi.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }

    public ICollection<StudentCourse>StudentCourses {get; set;} = new List<StudentCourse>();
}