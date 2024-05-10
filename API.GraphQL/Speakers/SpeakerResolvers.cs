using API.Application.Speakers;
using API.Domain.Models;
using HotChocolate.Resolvers;

namespace API.GraphQL.Speakers;

public class SpeakerResolvers
{
    public async Task<IEnumerable<Session>> GetSessionsAsync(
        [Parent] Speaker speaker,
        [Service] ISpeakerRepository repository,
        IResolverContext context,
        CancellationToken cancellationToken
    )
    {
        var sessionsBySpeaker = context.GroupDataLoader<int, Session>(
            (keys, _) =>
                Task.FromResult(
                    repository.GetSessionsBySpeakers(keys).Project(context).ToLookup(s => s.Id)
                ),
            dataLoaderName: "SessionsBySpeakerLoader"
        );

        return await sessionsBySpeaker.LoadAsync(speaker.Id, cancellationToken);
    }
}
