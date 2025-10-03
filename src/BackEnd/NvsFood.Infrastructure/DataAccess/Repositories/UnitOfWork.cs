using NvsFood.Domain.Interfaces;

namespace NvsFood.Infrastructure.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    
    private readonly NvsFoodDbContext _context;

    public UnitOfWork(NvsFoodDbContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}