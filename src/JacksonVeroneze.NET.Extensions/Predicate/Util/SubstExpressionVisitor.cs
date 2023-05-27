using System.Linq.Expressions;

namespace JacksonVeroneze.NET.Extensions.Predicate.Util;

internal class SubstExpressionVisitor : ExpressionVisitor
{
    public readonly Dictionary<Expression, Expression> subst = new();

    protected override Expression VisitParameter(
        ParameterExpression node)
    {
        return subst.TryGetValue(node, out Expression? newValue)
            ? newValue
            : node;
    }
}