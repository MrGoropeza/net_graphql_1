using API.Application.Sessions;
using API.Application.Speakers;
using API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence;

public static class ConfigurePersistence
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("SQLite");

        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<ISpeakerRepository, SpeakerRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();

        return services;
    }
}
