using System;

namespace iman.Result
{
    public class Result : Result<Result>
    {
        
        public Result(): base() { }
        
        public Result(ResultStatus status): base(status) { }
        
        public static Result Ok() => new Result();

        public static Result Ok(string message) => new Result() { Message = message };

        public static Result Error() => new Result(ResultStatus.Error);

        public static Result Error(params string[] errors)
            => new Result(ResultStatus.Error) { Errors = errors };

        public new static Result NotFound() => new Result(ResultStatus.NotFound);
        
    }
}