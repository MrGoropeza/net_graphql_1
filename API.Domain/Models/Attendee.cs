using System.ComponentModel.DataAnnotations;

namespace API.Domain.Models;

public class Attendee
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(200)]
    public string? LastName { get; set; }

    [Required]
    [StringLength(200)]
    public string? UserName { get; set; }

    [StringLength(256)]
    public string? EmailAddress { get; set; }

    public ICollection<SessionAttendee> SessionsAttendees { get; set; } = [];
}
