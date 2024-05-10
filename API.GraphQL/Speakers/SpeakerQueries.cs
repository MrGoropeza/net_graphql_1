using API.Application.Speakers;
using API.Domain.Models;
using API.GraphQL.Extensions;
using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace API.GraphQL.Speakers;

[ExtendObjectType(OperationType.Query)]
public class SpeakerQueries
{
    [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Speaker> GetSpeakers(
        ISpeakerRepository repository,
        IResolverContext context
    ) => repository.GetSpeakers().OrderByArgumentOrDefault(context, r => r.Name);

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Speaker> GetSpeaker(int id, ISpeakerRepository repository) =>
        repository.GetSpeakers().Where(s => s.Id == id);
}
