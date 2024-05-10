using API.Application.Sessions;
using API.Domain.Models;
using API.GraphQL.Extensions;
using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace API.GraphQL.Speakers;

[ExtendObjectType(OperationType.Query)]
public class SessionQueries
{
    [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Session> GetSessions(
        ISessionRepository repository,
        IResolverContext context
    ) => repository.GetSessions().OrderByArgumentOrDefault(context, r => r.Title);

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Session> GetSession(int id, ISessionRepository repository) =>
        repository.GetSessions().Where(s => s.Id == id);
}
