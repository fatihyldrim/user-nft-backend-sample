namespace UnivestHub.Case.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public string ErrorMessage { get; set; }
        public string Code { get; set; }
        public BusinessException(string errorMessage, string code) : base(errorMessage)
        {

            ErrorMessage = errorMessage;
            Code = code;
        }
    }
}
