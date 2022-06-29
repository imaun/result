using System;
using System.Linq;

namespace iman.Library.Results
{
    public static class ResultExtensions
    {

        public static PagedResult<T> ToPagedResult<T>(
            this Result<T> result, 
            int pageNumber,
            int pageSize,
            int totalCount)
        {
            return new PagedResult<T>(result)
                .WithPageNumber(pageNumber)
                .WithPageSize(pageSize)
                .WithTotalCount(totalCount);
        }

        public static IResult Then(this IResult result, Action action)
        {
            if (result.IsSuccess) action();
            return result;
        }

        public static IResult<T> Then<T>(this IResult<T> result, Action<T> action)
        {
            if (result.IsSuccess)
                action(result.Value);

            return result;
        }

        public static IResult<T> Ensure<T>(this IResult<T> result, Func<T, bool> predicate)
        {
            if (result.HasError) return result;

            return predicate(result.Value)
                ? Result<T>.Ok(result.Value)
                : Result<T>.Error(Array.Empty<string>());
        }

        public static T Finally<T>(this IResult result, Func<IResult, T> func)
        {
            return func(result);
        }
        
        
    }
}