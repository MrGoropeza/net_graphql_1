namespace API.GraphQL.Common;

public abstract class Payload(IReadOnlyList<UserError>? errors = null)
{
    public IReadOnlyList<UserError>? Errors { get; } = errors;
}
