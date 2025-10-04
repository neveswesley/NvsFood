using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NvsFood.Application.Services.AutoMapper;
using NvsFood.Application.Services.Criptography;
using NvsFood.Application.UseCases.User.Register;
using NvsFood.Domain.Repositories.User;

namespace NvsFood.Application;

public static class DependenceInjectionExtension
{
    
    
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddUseCases(services);
        AddAutoMapper(services);
        AddPasswordEncripter(services, configuration);
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

    private static void AddPasswordEncripter(IServiceCollection services, IConfiguration configuration)
    {
        var additionalKey = configuration.GetValue<string>("Settings:Password:AdditionalKey");
        services.AddScoped(options => new PasswordEncripter(additionalKey!));
    }
    
}