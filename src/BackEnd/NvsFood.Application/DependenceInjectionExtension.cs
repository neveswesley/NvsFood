using Microsoft.Extensions.DependencyInjection;
using NvsFood.Application.Services.AutoMapper;
using NvsFood.Application.Services.Criptography;
using NvsFood.Application.UseCases.User.Register;
using NvsFood.Domain.Repositories.User;

namespace NvsFood.Application;

public static class DependenceInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddAutoMapper(services);
        AddPasswordEncripter(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>  
        {  
            cfg.AddProfile<AutoMapping>();  
        }, typeof(AutoMapping).Assembly);
    }

    private static void AddPasswordEncripter(IServiceCollection services)
    {
        services.AddScoped(options => new PasswordEncripter());
    }
    
}