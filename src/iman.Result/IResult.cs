using System.Collections.Generic;

namespace iman.Result
{
    public interface IResult
    {
        ResultStatus Status { get; }
        
        IEnumerable<string> Errors { get; }
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
    }
}