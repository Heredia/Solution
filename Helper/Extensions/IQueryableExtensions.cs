using Helper.Enums;
using System;
using System.Linq;
using System.Linq.Expressions;

public static class IQueryableExtensions
{
    public static IQueryable<T> Filter<T>(this IQueryable<T> queryable, string property, Condition condition, object value)
    {
        if (queryable == null || !queryable.Any() || string.IsNullOrWhiteSpace(property)) { return queryable; }

        var propertyInfo = typeof(T).GetProperty(property.Split('.').Last());
        if (propertyInfo == null) return queryable;

        var parameter = Expression.Parameter(typeof(T), "x");
        var member = Expression.Property(parameter, propertyInfo);

        try { value = Convert.ChangeType(value, propertyInfo.PropertyType); } catch { return null; }

        var constant = Expression.Constant(value, propertyInfo.PropertyType);
        Expression expression;

        if (propertyInfo.PropertyType == typeof(string) && condition == Condition.Default)
        {
            condition = Condition.Contains;
        }

        switch (condition)
        {
            case Condition.NotEqual: { expression = Expression.NotEqual(member, constant); break; }
            case Condition.GreaterThan: { expression = Expression.GreaterThan(member, constant); break; }
            case Condition.GreaterThanOrEqual: { expression = Expression.GreaterThanOrEqual(member, constant); break; }
            case Condition.LessThan: { expression = Expression.LessThan(member, constant); break; }
            case Condition.LessThanOrEqual: { expression = Expression.LessThanOrEqual(member, constant); break; }
            case Condition.Contains:
                {
                    var methodInfo = propertyInfo.PropertyType.GetMethod("Contains");
                    expression = Expression.Call(member, methodInfo, constant);
                    break;
                }
            default: { expression = Expression.Equal(member, constant); break; }
        }

        var lambda = Expression.Lambda(expression, parameter);
        var method = Expression.Call(typeof(Queryable), "Where", new[] { queryable.ElementType }, queryable.Expression, lambda);
        return queryable.Provider.CreateQuery<T>(method);
    }

    public static IQueryable<T> Order<T>(this IQueryable<T> queryable, string property, bool isAscending)
    {
        if (queryable == null || !queryable.Any() || string.IsNullOrEmpty(property)) return queryable;

        var propertyInfo = typeof(T).GetProperty(property.Split('.').Last());
        if (propertyInfo == null) return queryable;

        var parameter = Expression.Parameter(typeof(T), "x");
        var member = Expression.Property(parameter, propertyInfo);
        var lambda = Expression.Lambda(member, parameter);
        var methodName = isAscending ? "OrderBy" : "OrderByDescending";
        var method = Expression.Call(typeof(Queryable), methodName, new[] { typeof(T), propertyInfo.PropertyType }, queryable.Expression, Expression.Quote(lambda));
        return queryable.Provider.CreateQuery<T>(method);
    }

    public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int index, int pageSize)
    {
        if (queryable == null || !queryable.Any() || index == 0 || pageSize == 0) return queryable;
        return queryable.Skip((index - 1) * pageSize).Take(pageSize);
    }
}