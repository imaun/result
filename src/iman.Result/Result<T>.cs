using System;
using System.Collections.Generic;

namespace iman.Result
{
    /// <summary>
    /// Result class to represents response of a Domain logic, service, handler, query, etc..
    /// </summary>
    /// <typeparam name="T">type of <see cref="Value"/> that is important to the caller function.</typeparam>
    public class Result<T> : IResult<T>
    {
        protected Result() { }

        protected Result(T value)
        {
            Value = value;
        }

        protected internal Result(ResultStatus status)
        {
            Status = status;
        }

        protected internal Result(T value, string message)
        {
            Value = value;
            Message = message;
        }

        protected internal Result(ResultStatus status, string message)
        {
            Status = status;
            Message = message;
        }
        
        public static implicit operator T(Result<T> result) => result.Value;
        
        public static implicit operator Result<T>(T value) => new Result<T>(value);
        
        #region Properties

        public T Value { get; private set; }
        
        public Type ValueType { get; private set; }

        public ResultStatus Status { get; protected set; } = ResultStatus.Ok;

        public bool IsSuccess => Status == ResultStatus.Ok;

        public bool HasError => Status == ResultStatus.Error;

        public bool IsInvalid => Status == ResultStatus.Invalid;

        public IEnumerable<string> Errors { get; protected set; } = new List<string>();
        
        public string Message { get; protected set; }

        #endregion


        public static Result<T> Ok(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Ok(T value, string message)
        {
            return new Result<T>(value, message);
        }

        public static Result<T> Error(params string[] errors)
        {
            return new Result<T>(ResultStatus.Error) { Errors = errors };
        }

        public static Result<T> NotFound()
        {
            return new Result<T>(ResultStatus.NotFound);
        }

        public static Result<T> Unauthorized()
        {
            return new Result<T>(ResultStatus.Unauthorized);
        }
        
    }
}