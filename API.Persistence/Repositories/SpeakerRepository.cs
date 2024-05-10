using API.Application.Speakers;
using API.Domain.Models;

namespace API.Persistence.Repositories;

public class SpeakerRepository(AppDbContext dbContext) : ISpeakerRepository
{
    public IQueryable<Speaker> GetSpeakers() => dbContext.Speakers;

    public IQueryable<Session> GetSessionsBySpeakers(IReadOnlyList<int> keys) =>
        dbContext
            .Speakers.Where(s => keys.Contains(s.Id))
            .SelectMany(s => s.SessionSpeakers.Select(t => t.Session));

    public async Task<Speaker> AddSpeakerAsync(AddSpeakerInput input)
    {
        var speaker = new Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSite = input.WebSite
        };

        var result = dbContext.Speakers.Add(speaker);
        speaker = result.Entity;
        await dbContext.SaveChangesAsync();

        return speaker;
    }
}
