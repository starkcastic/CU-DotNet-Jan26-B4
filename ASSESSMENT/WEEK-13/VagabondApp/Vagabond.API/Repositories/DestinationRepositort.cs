using Microsoft.EntityFrameworkCore;
using Vagabond.API.Data;
using Vagabond.API.Exceptions;
using Vagabond.API.Models;

namespace Vagabond.API.Repositories;

public class DestinationRepository : IDestinationRepository
{
    private readonly AppDbContext _context;

    public DestinationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Destination>> GetAllAsync()
        => await _context.Destinations.ToListAsync();

    public async Task<Destination?> GetByIdAsync(int id)
        => await _context.Destinations.FindAsync(id);

    public async Task AddAsync(Destination destination)
    {
        _context.Destinations.Add(destination);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Destination destination)
    {
        _context.Destinations.Update(destination);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var destination = await _context.Destinations.FindAsync(id);
        if (destination is null)
            throw new DestinationNotFoundException(id);

        _context.Destinations.Remove(destination);
        await _context.SaveChangesAsync();
    }
}