using API.Domain.Models;
using API.GraphQL.Common;

namespace API.GraphQL.Speakers;

public class AddSpeakerPayload : SpeakerPayloadBase
{
    public AddSpeakerPayload(Speaker speaker)
        : base(speaker) { }

    public AddSpeakerPayload(IReadOnlyList<UserError> errors)
        : base(errors) { }
}

public class SpeakerPayloadBase : Payload
{
    protected SpeakerPayloadBase(Speaker speaker)
    {
        Speaker = speaker;
    }

    protected SpeakerPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors) { }

    public Speaker? Speaker { get; }
}
