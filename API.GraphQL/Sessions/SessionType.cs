using API.Domain.Models;

namespace API.GraphQL.Sessions;

public class SessionType : ObjectType<Session>
{
    protected override void Configure(IObjectTypeDescriptor<Session> descriptor)
    {
        descriptor
            .Field(t => t.SessionSpeakers)
            .ResolveWith<SessionResolvers>(t =>
                t.GetSpeakersAsync(default!, default!, default!, default!)
            )
            .Name("speakers")
            .UseProjection()
            .IsProjected(false);

        descriptor
            .Field(t => t.SessionAttendees)
            .ResolveWith<SessionResolvers>(t =>
                t.GetAttendeesAsync(default!, default!, default!, default!)
            )
            .Name("attendees")
            .UseProjection()
            .IsProjected(false);
    }
}
