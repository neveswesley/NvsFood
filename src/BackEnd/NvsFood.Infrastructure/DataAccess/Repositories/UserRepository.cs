using Microsoft.EntityFrameworkCore;
using NvsFood.Domain.Entities;
using NvsFood.Domain.Repositories.User;

namespace NvsFood.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly NvsFoodDbContext _context;

    public UserRepository(NvsFoodDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistActiveUserWithEmail(string email) => await _context.Users.AnyAsync(u => u.Email.Equals(email) && u.Active == true);
    public async Task Add(User user) => await _context.Users.AddAsync(user);
}