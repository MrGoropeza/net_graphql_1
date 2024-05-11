using API.Application.Sessions;
using API.Application.Speakers;
using API.Persistence;
using HotChocolate.Execution.Configuration;

namespace API.GraphQL;

public static class ConfigureGraphQL
{
    public static IServiceCollection AddGraphQLServices(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .RegisterDbContext<AppDbContext>(DbContextKind.Synchronized)
            .ModifyRequestOptions(x => x.IncludeExceptionDetails = true)
            .ConfigureQueries()
            .ConfigureMutations()
            .ConfigureSubscriptions();

        return services;
    }

    public static IRequestExecutorBuilder ConfigureQueries(this IRequestExecutorBuilder builder) =>
        builder
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .AddQueryType()
            .RegisterService<ISpeakerRepository>(ServiceKind.Synchronized)
            .RegisterService<ISessionRepository>(ServiceKind.Synchronized)
            .AddGraphQLTypes();

    public static IRequestExecutorBuilder ConfigureMutations(
        this IRequestExecutorBuilder builder
    ) => builder.AddMutationType().AddMutationConventions();

    public static IRequestExecutorBuilder ConfigureSubscriptions(
        this IRequestExecutorBuilder builder
    ) => builder.AddInMemorySubscriptions().AddSubscriptionType();

    public static void UseGraphQL(this WebApplication app)
    {
        app.UseWebSockets();
        app.MapGraphQL();
    }
}
