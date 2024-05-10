using API.Domain.Models;

namespace API.GraphQL.Speakers;

public class SpeakerType : ObjectType<Speaker>
{
    protected override void Configure(IObjectTypeDescriptor<Speaker> descriptor)
    {
        descriptor
            .Field(t => t.SessionSpeakers)
            .ResolveWith<SpeakerResolvers>(t =>
                t.GetSessionsAsync(default!, default!, default!, default!)
            )
            .Name("sessions")
            .UseProjection()
            .IsProjected(false);
    }
}
