using API.Application.Sessions;
using API.Domain.Models;
using HotChocolate.Resolvers;

namespace API.GraphQL.Sessions;

public class SessionResolvers
{
    public async Task<IEnumerable<Speaker>> GetSpeakersAsync(
        [Parent] Session session,
        [Service] ISessionRepository repository,
        IResolverContext context,
        CancellationToken cancellationToken
    )
    {
        var speakersBySession = context.GroupDataLoader<int, Speaker>(
            (keys, _) =>
                Task.FromResult(
                    repository.GetSpeakersBySessions(keys).Project(context).ToLookup(s => s.Id)
                ),
            dataLoaderName: "SpeakersBySessionLoader"
        );

        return await speakersBySession.LoadAsync(session.Id, cancellationToken);
    }

    public async Task<IEnumerable<Attendee>> GetAttendeesAsync(
        [Parent] Session session,
        [Service] ISessionRepository repository,
        IResolverContext context,
        CancellationToken cancellationToken
    )
    {
        var attendeesBySession = context.GroupDataLoader<int, Attendee>(
            (keys, _) =>
                Task.FromResult(
                    repository.GetAttendeesBySessions(keys).Project(context).ToLookup(a => a.Id)
                ),
            dataLoaderName: "AttendeesBySessionLoader"
        );

        return await attendeesBySession.LoadAsync(session.Id, cancellationToken);
    }
}
