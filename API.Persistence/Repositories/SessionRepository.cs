using API.Application.Sessions;
using API.Domain.Models;

namespace API.Persistence.Repositories;

public class SessionRepository(AppDbContext dbContext) : ISessionRepository
{
    public IQueryable<Speaker> GetSpeakersBySessions(IReadOnlyList<int> keys) =>
        dbContext
            .Sessions.Where(s => keys.Contains(s.Id))
            .SelectMany(s => s.SessionSpeakers.Select(t => t.Speaker));

    public IQueryable<Attendee> GetAttendeesBySessions(IReadOnlyList<int> keys) =>
        dbContext
            .Sessions.Where(s => keys.Contains(s.Id))
            .SelectMany(s => s.SessionAttendees.Select(t => t.Attendee));

    public IQueryable<Session> GetSessions() => dbContext.Sessions;
}
