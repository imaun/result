using System;
using System.Collections.Generic;

namespace iman.Library.Results
{
    public class Result : IResult
    {

        protected Result()
        {
            Status = ResultStatus.Ok;
        }

        protected Result(ResultStatus status)
        {
            Status = status;
        }

        protected Result(string message)
        {
            Status = ResultStatus.Ok;
            Message = message;
        }

        #region Properties

        public ResultStatus Status { get; protected set; } = ResultStatus.Ok;

        public bool IsSuccess => Status == ResultStatus.Ok;

        public bool HasError => Status == ResultStatus.Error;

        public bool IsInvalid => Status == ResultStatus.Invalid;

        public IEnumerable<string> Errors { get; protected set; } = new List<string>();
        
        public Exception Exception { get; protected set; }
        
        public string Message { get; protected set; }

        #endregion
        
        public static Result Ok() => new Result();

        public static Result Ok(string message) => new Result() { Message = message };

        public static Result Error() => new Result(ResultStatus.Error);

        public new static Result Error(params string[] errors)
            => new Result(ResultStatus.Error) { Errors = errors };

        public new static Result NotFound() => new Result(ResultStatus.NotFound);
        
    }
}