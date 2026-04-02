using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentApi.Data;
using FluentApi.Models;

namespace FluentApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class StudentController : ControllerBase
{
    public readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    //api/stduents
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _context.Students
                        .Include(s => s.StudentCourses)
                        .ThenInclude(sc => sc.Course)
                        .ToListAsync();
        
        return Ok(students);
    }

    // GET /api/students/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _context.Students
                        .Include(s => s.StudentCourses)
                            .ThenInclude(sc => sc.Course)
                        .FirstOrDefaultAsync(s => s.Id == id);
        
        if(student is null)
            return NotFound(new {message = $"Student with {id} not found"});
        
        return Ok(student);
    }

    // POST /api/students
    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        bool emailexits = await _context.Students
                            .AnyAsync(s => s.Email == student.Email);
        
        if(emailexits)
            return BadRequest(new {Message = $"Email already exist"});

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById) , new {id = student.Id} , student);
    }

    // PUT /api/students/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id , Student updated)
    {
        var student = await _context.Students.FindAsync(id);
        
        if(student is null)
            return NotFound(new {Message = $"Student with {id} not found"});
        
        student.Name = updated.Name;
        student.Email = updated.Email;
        student.Age = updated.Age;

        await _context.SaveChangesAsync();

        return Ok(student);
    }

    // DELETE /api/students/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if(student is null)
            return NotFound( new {Message = $"Student with {id} not found"});
        
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return Ok(new {Message = $"Student with {id} deleted"});
    }
}