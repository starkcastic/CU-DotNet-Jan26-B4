using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentApi.Data;
using FluentApi.Models;


namespace FluentApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CourseController : ControllerBase
{
    public readonly AppDbContext _context;

    public CourseController(AppDbContext context)
    {
        _context = context;
    }

    //{/api/course}
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _context.Courses
            .Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
            .ToListAsync();

        
        return Ok(courses);
    }

    // {/api/course/id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = _context.Courses
                    .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Student)
                    .FirstOrDefault(s => s.Id == id);
        
        if(course is null)
            return NotFound(new {message = $"course with {id} not found"});
        
        return Ok(course);
    }

    // post {/api/courses}
    [HttpPost]
    public async Task<IActionResult> Create(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById) , new {id = course.Id} , course);
    }

    // put {api/couses/{id}}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id , Course updated)
    {
        var course = await _context.Courses.FindAsync(id);

        if(course is null)
            return NotFound(new {message = $"Course with {id} not found"});
        
        course.Title = updated.Title;
        course.Credit = updated.Credit;

        await _context.SaveChangesAsync();
        return Ok(course);
    }

    // {api/delete/{id}}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if(course is null)
            return NotFound(new {message = $"Course with {id} not found"});
        
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return Ok(new {message = $"Course with {id} is deleted"});
    }
}