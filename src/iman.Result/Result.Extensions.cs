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

        public static IResult<T> Ensure<T>(this IResult<T> result, Func<T, bool> predicate)
        {
            if (result.HasError) return result;

            return predicate(result.Value)
                ? Result<T>.Ok(result.Value)
                : Result<T>.Error(Array.Empty<string>());
        }
    }
}