using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;

namespace DynamicFilter.Models
{
    public static class DynamicFilter
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> source, IList<FieldContrainte> fieldContraintes)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var parameter = Expression.Parameter(typeof(T));

            var body = createExpression<T>(parameter, fieldContraintes);
            if (body == null) return source;

            var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
            return source.Where(predicate);
        }

        static Expression createExpression<T>(Expression target, IList<FieldContrainte> fieldContraintes)
        {
            Expression result = null;

            foreach (var fieldContrainte in fieldContraintes)
            {
                //Expression expressions = null;
                var propertie = target.Type
                      .GetProperties()
                      .FirstOrDefault(x => x.CanRead && x.Name == fieldContrainte.FieldName);

                if (propertie != null)
                {
                    foreach (var contrainte in fieldContrainte.Contraintes)
                    {
                        Expression condition = null;
                        var propValue = Expression.MakeMemberAccess(target, propertie);

                        if (propertie.PropertyType == typeof(string))
                        {
                            condition = createStringCondition<T>(propValue, contrainte);
                        }
                        else if (propertie.PropertyType == typeof(Int32))
                        {
                            condition = createInt32Condition<T>(propValue, contrainte);
                        }
                        else if (propertie.PropertyType == typeof(Nullable<Int32>))
                        {
                            condition = createNullableInt32Condition<T>(propValue, contrainte, propertie.PropertyType);
                        }
                        else if (!propertie.PropertyType.Namespace.StartsWith("System."))
                        {
                            //condition = SearchStrings(propValue, property, matchMode, value);
                        }
                        if (condition != null && fieldContrainte.Operator == "or")
                            result = result == null ? condition : Expression.OrElse(result, condition);
                        else if (condition != null && fieldContrainte.Operator == "and")
                            result = result == null ? condition : Expression.AndAlso(result, condition);
                    }
                }
            }

            return result;
        }

        private static Expression createNullableInt32Condition<T>(Expression propValue, Contrainte contrainte, Type propertyType)
        {
            int? value = Int32.Parse(contrainte.Value);
            var valueExpression = Expression.Convert(Expression.Constant(value), propertyType);
            switch (contrainte.MatchMode)
            {
                case "equals":
                    return Expression.Equal(propValue, valueExpression);
                case "notEquals":
                    return Expression.Not(Expression.Equal(propValue, valueExpression));
                case "lt":
                    return Expression.LessThan(propValue, valueExpression);
                case "lte":
                    return Expression.LessThanOrEqual(propValue, valueExpression);
                case "gt":
                    return Expression.GreaterThan(propValue, valueExpression);
                case "gte":
                    return Expression.GreaterThanOrEqual(propValue, valueExpression);
                default:
                    throw new NotImplementedException($"matchMode node implemented");
            }
        }

        static Expression createInt32Condition<T>(Expression propValue, Contrainte contrainte)
        {
            var value = Int32.Parse(contrainte.Value);
            var parameter = Expression.Parameter(typeof(T));
            var valueExpression = Expression.Property(Expression.Constant(new { value }), nameof(value));
            switch (contrainte.MatchMode)
            {
                case "equals":
                    return Expression.Equal(propValue, valueExpression);
                case "notEquals":
                    return Expression.Not(Expression.Equal(propValue, valueExpression));
                case "lt":
                    return Expression.LessThan(propValue, valueExpression);
                case "lte":
                    return Expression.LessThanOrEqual(propValue, valueExpression);
                case "gt":
                    return Expression.GreaterThan(propValue, valueExpression);
                case "gte":
                    return Expression.GreaterThanOrEqual(propValue, valueExpression);
                default:
                    throw new NotImplementedException($"matchMode node implemented");
            }
        }

        static Expression createStringCondition<T>(Expression propValue, Contrainte contrainte)
        {
            var value = Convert.ToString(contrainte.Value).ToLower();
            var parameter = Expression.Parameter(typeof(T));
            var valueExpression = Expression.Property(Expression.Constant(new { value }), nameof(value));
            switch (contrainte.MatchMode)
            {
                case "startsWith":
                    var startsWithComparand = Expression.Call(propValue, nameof(string.ToLower), Type.EmptyTypes);
                    return Expression.Call(startsWithComparand, nameof(string.StartsWith), Type.EmptyTypes, valueExpression);
                case "contains":
                    var containsComparand = Expression.Call(propValue, nameof(string.ToLower), Type.EmptyTypes);
                    return Expression.Call(containsComparand, nameof(string.Contains), Type.EmptyTypes, valueExpression);
                case "notContains":
                    var notContainsComparand = Expression.Call(propValue, nameof(string.ToLower), Type.EmptyTypes);
                    return Expression.Not(Expression.Call(notContainsComparand, nameof(string.Contains), Type.EmptyTypes, valueExpression));
                case "endsWith":
                    var endsWithComparand = Expression.Call(propValue, nameof(string.ToLower), Type.EmptyTypes);
                    return Expression.Call(endsWithComparand, nameof(string.EndsWith), Type.EmptyTypes, valueExpression);
                case "equals":
                    var equalsComparand = Expression.Call(propValue, nameof(string.ToLower), Type.EmptyTypes);
                    return Expression.Call(equalsComparand, nameof(string.Equals), Type.EmptyTypes, valueExpression);
                case "notEquals":
                    var notEqualsComparand = Expression.Call(propValue, nameof(string.ToLower), Type.EmptyTypes);
                    return Expression.Not(Expression.Call(notEqualsComparand, nameof(string.Equals), Type.EmptyTypes, valueExpression));
                default:
                    throw new NotImplementedException($"matchMode node implemented");
            }
        }
    }
}
