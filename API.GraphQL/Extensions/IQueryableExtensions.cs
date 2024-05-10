using System.Linq.Expressions;
using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace API.GraphQL.Extensions;

public static class IQueryableExtensions
{
    public static bool HasOrderByArgument(
        this IResolverContext context,
        string argumentName = "order"
    )
    {
        try
        {
            var orderByArgument = context.ArgumentLiteral<IValueNode>(argumentName);
            return orderByArgument != null && orderByArgument != NullValueNode.Default;
        }
        catch
        {
            return false;
        }
    }

    public static IQueryable<T> OrderByArgumentOrDefault<T>(
        this IQueryable<T> query,
        IResolverContext context,
        IQueryable<T> orderedQuery,
        string argumentName = "order"
    ) => context.HasOrderByArgument(argumentName) ? query : orderedQuery;

    public static IQueryable<T> OrderByArgumentOrDefault<T>(
        this IQueryable<T> query,
        IResolverContext context,
        Expression<Func<T, string>> defaultOrder,
        string argumentName = "order"
    ) => context.HasOrderByArgument(argumentName) ? query : query.OrderBy(defaultOrder);
}
