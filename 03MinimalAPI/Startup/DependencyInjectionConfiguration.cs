using _03MinimalAPI.Repositories;
using _03MinimalAPI.Services;
using FluentValidation;

namespace _03MinimalAPI.Startup;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddAutoMapper(typeof(Program));
        services.AddValidatorsFromAssemblyContaining<Program>();
        services.AddEndpoints();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSingleton<IWineService, WineService>();
        services.AddSingleton<IWineRepository, WineRepository>();

        return services;
    }
}
