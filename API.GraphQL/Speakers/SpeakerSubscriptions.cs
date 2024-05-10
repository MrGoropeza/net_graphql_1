using API.Domain.Models;
using HotChocolate.Language;

namespace API.GraphQL.Speakers;

[ExtendObjectType(OperationType.Subscription)]
public class SpeakerSubscriptions
{
    [Subscribe]
    [Topic(nameof(SpeakerMutations.AddSpeakerAsync))]
    public Speaker OnSpeakerAdded([EventMessage] Speaker addedSpeaker) => addedSpeaker;
}
