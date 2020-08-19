using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MyMoon.Application
{
    public static class QueryFilterExtensions
    {

        public static IQueryable<TSource> Filter<TSource>(this IQueryable<TSource> source, string value, Expression<Func<TSource, string>> property)
        {
            if (string.IsNullOrEmpty(value)) return source;

            if (property == null) throw new ArgumentNullException(nameof(property));

            if (property.Body.NodeType != ExpressionType.MemberAccess) throw new ArgumentException("expression property should be of member access");

            ParameterExpression param = Expression.Parameter(typeof(TSource), property.Parameters[0].Name);
            MemberExpression member = Expression.Property(param, property.GetMember().Name);
            MethodInfo methodContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            MethodCallExpression methodCall = Expression.Call(member, methodContains, Expression.Constant(value));
            var lambda = Expression.Lambda<Func<TSource, bool>>(methodCall, param);

            return source.AddPredicate(lambda);
        }

        public static IQueryable<TSource> Filter<TSource, TStruct>(this IQueryable<TSource> source, TStruct? from, TStruct? to, Expression<Func<TSource, DateTime>> property) where TStruct : struct
        {
            if (property == null) throw new ArgumentNullException(nameof(property));

            if (property.Body.NodeType != ExpressionType.MemberAccess) throw new ArgumentException("expression property should be of member access");

            if (!from.HasValue && !to.HasValue) return source;

            ParameterExpression param = Expression.Parameter(typeof(TSource), property.Parameters[0].Name);

            MemberExpression member = Expression.PropertyOrField(param, property.GetMember().Name);

            if (from.HasValue)
            {
                BinaryExpression body = Expression.GreaterThanOrEqual(member, Expression.Constant(from));
                var lambda = Expression.Lambda<Func<TSource, bool>>(body, param);
                source = source.AddPredicate(lambda);
            }

            if (to.HasValue)
            {
                BinaryExpression body = Expression.LessThanOrEqual(member, Expression.Constant(to));
                var lambda = Expression.Lambda<Func<TSource, bool>>(body, param);
                source = source.AddPredicate(lambda);
            }

            return source;
        }

        public static IQueryable<TSource> AddPredicate<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return source.Where(predicate);
        }
    }
}
