namespace API.Domain.Models;

public class SessionAttendee
{
    public int SessionId { get; set; }

    public Session Session { get; set; } = default!;

    public int AttendeeId { get; set; }

    public Attendee Attendee { get; set; } = default!;
}
