using System;
using System.Collections.Generic;

namespace iman.Result
{
    public interface IResult
    {
        ResultStatus Status { get; }
        
        IEnumerable<string> Errors { get; }
        
        Exception Exception { get; }
        
        string Message { get; }
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
        
        
    }
}