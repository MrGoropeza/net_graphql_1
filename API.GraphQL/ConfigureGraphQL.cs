using API.Application.Sessions;
using API.Application.Speakers;
using API.GraphQL.Sessions;
using API.GraphQL.Speakers;
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
            .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<SpeakerQueries>()
            .AddType<SpeakerType>()
            .AddTypeExtension<SessionQueries>()
            .AddType<SessionType>()
            .RegisterService<ISpeakerRepository>(ServiceKind.Synchronized)
            .RegisterService<ISessionRepository>(ServiceKind.Synchronized);

    public static IRequestExecutorBuilder ConfigureMutations(
        this IRequestExecutorBuilder builder
    ) => builder.AddMutationType(d => d.Name("Mutation")).AddTypeExtension<SpeakerMutations>();

    public static IRequestExecutorBuilder ConfigureSubscriptions(
        this IRequestExecutorBuilder builder
    ) =>
        builder
            .AddInMemorySubscriptions()
            .AddSubscriptionType(d => d.Name("Subscription"))
            .AddTypeExtension<SpeakerSubscriptions>();

    public static void UseGraphQL(this WebApplication app)
    {
        app.UseWebSockets();

        app.MapGraphQL();
    }
}
