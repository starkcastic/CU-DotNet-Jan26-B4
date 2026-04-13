namespace FluentApi.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Credit { get; set; }

     public ICollection<StudentCourse>StudentCourses {get; set;} = new List<StudentCourse>();

}