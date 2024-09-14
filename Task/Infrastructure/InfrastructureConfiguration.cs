using Application.Contracts;
using Application.Contracts.Common;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Common;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskDbContext>(options => {
            options.UseNpgsql(configuration.GetConnectionString("Database"));
        });
        services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IIncidentRepository, IncidentRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IIncidentService, IncidentService>();
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }
}