using System.ComponentModel.DataAnnotations;

namespace API.Domain.Models;

public class Session
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = default!;

    [StringLength(4000)]
    public string Abstract { get; set; } = default!;

    public DateTimeOffset? StartTime { get; set; }

    public DateTimeOffset? EndTime { get; set; }

    // Bonus points to those who can figure out why this is written this way
    public TimeSpan Duration =>
        EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue) ?? TimeSpan.Zero;

    public int? TrackId { get; set; }

    public ICollection<SessionSpeaker> SessionSpeakers { get; set; } = [];

    public ICollection<SessionAttendee> SessionAttendees { get; set; } = [];

    public Track? Track { get; set; }
}
