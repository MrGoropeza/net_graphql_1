using API.Domain.Models;

namespace API.Application.Speakers;

public interface ISpeakerRepository
{
    IQueryable<Speaker> GetSpeakers();
    IQueryable<Session> GetSessionsBySpeakers(IReadOnlyList<int> keys);
    Task<Speaker> AddSpeakerAsync(AddSpeakerInput input);
}
