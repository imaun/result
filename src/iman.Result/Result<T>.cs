using System;
using System.Collections.Generic;

namespace iman.Library.Results
{
    /// <summary>
    /// Result class to represents response of a Domain logic, service, handler, query, etc..
    /// </summary>
    /// <typeparam name="T">type of <see cref="Value"/> that is important to the caller function.</typeparam>
    public class Result<T> : Result, IResult<T>
    {
        protected Result(): base() { }

        protected Result(string message): base(message) { }
        
        protected Result(T value): base()
        {
            Value = value;
        }

        protected internal Result(ResultStatus status): base(status) { }
        
        protected internal Result(ResultStatus status, T value) : base(status)
        {
            Value = value;
        }

        protected internal Result(T value, string message) : base(message)
        {
            Value = value;
        }

        public static implicit operator T(Result<T> result) => result.Value;
        
        public static implicit operator Result<T>(T value) => new Result<T>(value);
        
        #region Properties

        public T Value { get; private set; }
        
        public Type ValueType { get; private set; }
        
        #endregion
        
        public static Result<T> Ok(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Ok(T value, string message)
        {
            return new Result<T>(value, message);
        }

        public new static Result<T> Error(params string[] errors)
        {
            return new Result<T>(ResultStatus.Error) { Errors = errors };
        }

        public new static Result<T> Error(Exception exception)
        {
            return new Result<T>() { Exception = exception };
        }
        
    }
}