using API.Application.Speakers;
using HotChocolate.Language;
using HotChocolate.Subscriptions;

namespace API.GraphQL.Speakers;

[ExtendObjectType(OperationType.Mutation)]
public class SpeakerMutations
{
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        ISpeakerRepository repository,
        [Service] ITopicEventSender eventSender
    )
    {
        var speaker = await repository.AddSpeakerAsync(input);

        await eventSender.SendAsync(nameof(AddSpeakerAsync), speaker);

        return new AddSpeakerPayload(speaker);
    }
}
