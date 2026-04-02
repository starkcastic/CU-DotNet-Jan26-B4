using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentApi.Data;
using FluentApi.Models;


namespace FluentApi.Controllers;

public class EnrollRequest
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
}


[ApiController]
[Route("api/[controller]")]
public class EnrollmentController : ControllerBase
{
    public readonly AppDbContext _context;
    
    public EnrollmentController(AppDbContext context)
    {
        _context = context;
    }

    // {api/enroll}

    [HttpPost]
    public async Task<IActionResult> Enroll(EnrollRequest request)
    {
        var student = await _context.Students.FindAsync(request.StudentId);

        if (student is null)
            return NotFound(new { message = $"Student with Id {request.StudentId} not found." });
        
        var course = await _context.Courses.FindAsync(request.CourseId);

        if (course is null)
            return NotFound(new { message = $"Course with Id {request.CourseId} not found." });

        bool alreadyEnrolled = await _context.StudentCourses
                        .AnyAsync(sc => sc.StudentId == request.StudentId 
                            && sc.CourseId == request.CourseId);

        if (alreadyEnrolled)
            return BadRequest(new { message = "Student is already enrolled in this course." });

        var enrollment = new StudentCourse
        {
            StudentId = request.StudentId,
            CourseId = request.CourseId
        };

        _context.StudentCourses.Add(enrollment);
        await _context.SaveChangesAsync();

        return Ok(new { message = $"Student '{student.Name}' enrolled in '{course.Title}' successfully." });
    }
}