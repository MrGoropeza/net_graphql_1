namespace API.Domain.Models;

public class SessionSpeaker
{
    public int SessionId { get; set; }

    public Session Session { get; set; } = default!;

    public int SpeakerId { get; set; }

    public Speaker Speaker { get; set; } = default!;
}
