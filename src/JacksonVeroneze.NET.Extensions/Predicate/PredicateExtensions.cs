using System.Linq.Expressions;
using JacksonVeroneze.NET.Extensions.Predicate.Util;

namespace JacksonVeroneze.NET.Extensions.Predicate;

public static class PredicateExtensions
{
    public static Expression<Func<TType, bool>> And<TType>(
        this Expression<Func<TType, bool>> a,
        Expression<Func<TType, bool>> b)
    {
        ParameterExpression parameter = a.Parameters[0];

        SubstExpressionVisitor visitor = new()
        {
            subst =
            {
                [b.Parameters[0]] = parameter
            }
        };

        BinaryExpression body = Expression
            .AndAlso(a.Body, visitor.Visit(b.Body));

        return Expression
            .Lambda<Func<TType, bool>>(body, parameter);
    }

    public static Expression<Func<TType, bool>> Or<TType>(
        this Expression<Func<TType, bool>> a,
        Expression<Func<TType, bool>> b)
    {
        ParameterExpression parameter = a.Parameters[0];

        SubstExpressionVisitor visitor = new()
        {
            subst =
            {
                [b.Parameters[0]] = parameter
            }
        };

        BinaryExpression body = Expression
            .Or(a.Body, visitor.Visit(b.Body));

        return Expression
            .Lambda<Func<TType, bool>>(body, parameter);
    }
}