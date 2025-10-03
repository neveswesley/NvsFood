using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NvsFood.Domain.Interfaces;
using NvsFood.Domain.Repositories.User;
using NvsFood.Infrastructure.DataAccess;
using NvsFood.Infrastructure.DataAccess.Repositories;

namespace NvsFood.Infrastructure;

public static class DependenceInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddRepositories(services);
        AddDbContext(services);
        AddUnitOfWork(services);
    }

    private static void AddDbContext(IServiceCollection services)
    {

        var connectionString = "Server=WESLEY\\SQLEXPRESS;Database=NvsFoodDb;User ID=sa;Password=1q2w3e4r5t@#;TrustServerCertificate=True;";
        
        services.AddDbContext<NvsFoodDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseSqlServer(connectionString);
        });
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }

    private static void AddUnitOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}