using API.Domain.Models;

namespace API.Application.Sessions;

public interface ISessionRepository
{
    IQueryable<Session> GetSessions();
    IQueryable<Speaker> GetSpeakersBySessions(IReadOnlyList<int> keys);
    IQueryable<Attendee> GetAttendeesBySessions(IReadOnlyList<int> keys);
}
