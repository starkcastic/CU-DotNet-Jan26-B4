using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PageVaultAPI.Data;
using PageVaultAPI.Models;

namespace PageVaultAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly PageVaultDbContext _context;
    private readonly ILogger<BooksController> _logger;

    public BooksController(
        PageVaultDbContext context,
        ILogger<BooksController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET /api/books
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        _logger.LogInformation("GET /api/books hit — fetching all books.");

        var books = await _context.Books
            .Include(b => b.Author)
            .ToListAsync();

        return Ok(books);
    }

    // GET /api/books/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        _logger.LogInformation("GET /api/books/{Id} hit.", id);

        var book = await _context.Books
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            _logger.LogWarning("Book with ID {Id} not found.", id);
            return NotFound(new { message = $"No book found with ID {id}." });
        }

        return Ok(book);
    }

    // POST /api/books
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] Book book)
    {
        _logger.LogInformation(
            "POST /api/books hit — creating book: {Title}.", book.Title);

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    // PUT /api/books/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
    {
        _logger.LogInformation("PUT /api/books/{Id} hit.", id);

        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            _logger.LogWarning(
                "Update failed — book with ID {Id} not found.", id);
            return NotFound(new { message = $"No book found with ID {id}." });
        }

        book.Title        = updatedBook.Title;
        book.Genre        = updatedBook.Genre;
        book.PublishedYear = updatedBook.PublishedYear;
        book.AuthorId     = updatedBook.AuthorId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE /api/books/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        _logger.LogInformation("DELETE /api/books/{Id} hit.", id);

        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            _logger.LogWarning(
                "Delete failed — book with ID {Id} not found.", id);
            return NotFound(new { message = $"No book found with ID {id}." });
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}