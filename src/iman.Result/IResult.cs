using System;
using System.Collections.Generic;

namespace iman.Library.Results
{
    public interface IResult
    {
        ResultStatus Status { get; }
        
        IEnumerable<string> Errors { get; }
        
        Exception Exception { get; }
        
        string Message { get; }
        
        bool HasError { get; }
        
        bool IsInvalid { get; }
        
        bool IsSuccess { get; }
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
        
        Type ValueType { get; }
    }
}