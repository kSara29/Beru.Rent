using Ad.Application.Contracts.TimeUnit;
using Ad.Domain.Models;
using Ad.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ad.Infrastructure.Database;

public class TimeUnitRepository :ITimeUnitRepository
{
    private readonly AdContext _context;

    public TimeUnitRepository(AdContext context)
    {
        _context = context;
    }
    public async Task<Guid> CreateAsync(TimeUnit entity)
    {
        await _context.TimeUnits.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<string> RemoveAsync(Guid id)
    {
        var entity = await _context.TimeUnits.FindAsync(id);
        if (entity == null)
        {
            return "Некорректный id, категория не найдена";
        }
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return "success";
    }

    public async Task<TimeUnit?> GetAsync(Guid id)
    {
        var entity = await _context.TimeUnits.FindAsync(id);
        return entity;
    }

    public async Task<List<TimeUnit?>> GetAllAsync()
    {
        var result = await _context.TimeUnits.ToListAsync();
        return result;
    }
}