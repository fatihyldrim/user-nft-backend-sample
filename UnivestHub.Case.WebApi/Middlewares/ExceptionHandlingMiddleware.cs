using UnivestHub.Case.Common.Exceptions;
using UnivestHub.Case.Common.ResponsePattern;
using System.Net;
using System.Text.Json;

namespace UnivestHub.Case.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            var errorMessage = new ErrorMessage();

            switch (exception)
            {
                case BusinessException ex:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorMessage.Description = ex.Message;
                    errorMessage.Code = ex.Code;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorMessage.Description = exception.Message;
                    break;
            }
            _logger.LogError(exception.Message);
            var apiResponse = new ApiResponse<NoContent>(errorMessage);
            var result = JsonSerializer.Serialize(apiResponse);
            await context.Response.WriteAsync(result);
        }
    }
}
