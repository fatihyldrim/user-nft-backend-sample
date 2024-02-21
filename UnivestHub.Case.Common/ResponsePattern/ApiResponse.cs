namespace UnivestHub.Case.Common.ResponsePattern
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public ErrorMessage? ErrorMessage { get; set; }

        public List<CustomValidationError>? ValidationErrors { get; set; }

        public bool IsSuccess { get; set; }

        /// <summary>
        ///  Success
        /// </summary>
        public ApiResponse(T? data)
        {
            this.Data = data;
            this.IsSuccess = true;
        }

        /// <summary>
        ///  Success
        /// </summary>
        public ApiResponse()
        {
            this.IsSuccess = true;
        }

        /// <summary>
        ///  Bussiness Exception
        /// </summary>
        /// <param name="errorMessage"></param>
        public ApiResponse(ErrorMessage errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.IsSuccess = false;

        }

        /// <summary>
        ///  Validation Exception
        /// </summary>
        /// <param name="errorMessage"></param>
        public ApiResponse(List<CustomValidationError> validationErrors)
        {
            this.ValidationErrors = validationErrors;
            this.IsSuccess = false;
        }
    }
}
