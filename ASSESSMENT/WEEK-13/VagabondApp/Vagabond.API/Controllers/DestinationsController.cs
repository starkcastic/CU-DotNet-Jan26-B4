using Microsoft.AspNetCore.Mvc;
using Vagabond.API.Exceptions;
using Vagabond.API.Models;
using Vagabond.API.Repositories;

namespace Vagabond.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DestinationsController : ControllerBase
{
    private readonly IDestinationRepository _repo;

    public DestinationsController(IDestinationRepository repo)
    {
        _repo = repo;
    }

    // GET /api/destinations
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _repo.GetAllAsync());

    // GET /api/destinations/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var destination = await _repo.GetByIdAsync(id);
        if (destination is null)
            throw new DestinationNotFoundException(id);
        return Ok(destination);
    }

    // POST /api/destinations
    [HttpPost]
    public async Task<IActionResult> Create(Destination destination)
    {
        await _repo.AddAsync(destination);
        return CreatedAtAction(nameof(GetById), new { id = destination.Id }, destination);
    }

    // PUT /api/destinations/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Destination destination)
    {
        if (id != destination.Id)
            return BadRequest("ID mismatch.");

        var existing = await _repo.GetByIdAsync(id);
        if (existing is null)
            throw new DestinationNotFoundException(id);

        await _repo.UpdateAsync(destination);
        return NoContent();
    }

    // DELETE /api/destinations/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}