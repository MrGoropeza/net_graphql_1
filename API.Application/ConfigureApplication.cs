using Microsoft.Extensions.DependencyInjection;

namespace API.Application;

public static class ConfigureApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
