namespace iman.Library.Results
{
    public enum ValidationLevel
    {
        Error = 0,
        Warning,
        Info
    }
    
    public class ValidationError
    {
        public ValidationError(
            string fieldName,
            string errorMessage,
            string errorCode = null,
            ValidationLevel level = ValidationLevel.Error)
        {
            FieldName = fieldName;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
            Level = level;
        }
        
        public string FieldName { get; private set; }
        public string ErrorMessage { get; private set; }
        public string ErrorCode { get; private set; }
        public ValidationLevel Level { get; private set; }

        public ValidationError HasFieldName(string fieldName)
        {
            FieldName = fieldName;
            return this;
        }

        public ValidationError HasErrorMessage(string errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        public ValidationError HasErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public ValidationError HasLevel(ValidationLevel level)
        {
            Level = level;
            return this;
        }
        
    }
}