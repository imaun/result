using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

        protected Result(ResultStatus status, string message)
        {
            Status = status;
            Message = message;
        }

        protected Result(string message)
        {
            Status = ResultStatus.Ok;
            Message = message;
        }

        #region Properties

        public ResultStatus Status { get; protected set; }

        public bool IsSuccess => Status == ResultStatus.Ok;

        public bool HasError => Status == ResultStatus.Error;

        public bool IsInvalid => Status == ResultStatus.Invalid;

        public bool IsValid => (!IsInvalid) && (!HasError);

        public IEnumerable<string> Errors { get; protected set; } = new List<string>();

        public ICollection<ValidationError> ValidationErrors { get; protected set; }
            = new List<ValidationError>();

        public Exception Exception { get; protected set; }
        
        public string Message { get; protected set; }

        #endregion

        #region Methods

        public void ThrowIfHasError(Exception exception)
        {
            if (HasError)
            {
                Exception = exception;
                throw exception;
            }
        }

        public void ClearValidationErrors()
        {
            ValidationErrors.Clear();
        }
        
        public IResult HasValidationErrors(IEnumerable<ValidationError> validationErrors)
        {
            ClearValidationErrors();
            return AddValidationErrors(validationErrors);
        }

        public IResult AddValidationErrors(IEnumerable<ValidationError> validationErrors)
        {
            if (validationErrors == null)
                throw new ArgumentNullException(nameof(validationErrors));
            
            foreach(var err in validationErrors) 
                ValidationErrors.Add(err);

            return this;
        }

        public void AddValidationError(ValidationError validationError)
        {
            if (validationError == null)
                throw new ArgumentNullException(nameof(validationError));
            
            ValidationErrors.Add(validationError);
        }

        public IResult HasValidationError(ValidationError validationError)
        {
            AddValidationError(validationError);
            return this;
        }
        
        
        
        #endregion

        #region Static Factories

        public static Result Ok() => new Result();

        public static Result Ok(string message) => new Result() { Message = message };

        public static Result Error() => new Result(ResultStatus.Error);

        public static Result Error(params string[] errors)
            => new Result(ResultStatus.Error) { Errors = errors };

        public static Result Error(Exception exception)
        
            => new Result(ResultStatus.Error) { Exception = exception };
        
        public static Result Invalid(IEnumerable<ValidationError> validationErrors)
            => new Result(ResultStatus.Invalid) { ValidationErrors = validationErrors.ToList() };
        
        public static Result NotFound() => new Result(ResultStatus.NotFound);

        public static Result Unauthorized() => new Result(ResultStatus.Unauthorized);

        #endregion



    }
}