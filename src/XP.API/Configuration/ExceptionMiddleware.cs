using Newtonsoft.Json;
using System.Net;
using XP.Business.Exception;

namespace XP.API.Configuration
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorResponse errorResponse;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                errorResponse = new ErrorResponse(HttpStatusCode.BadRequest.ToString(),
                                                      $"{ex.Message} {ex?.InnerException?.Message}") ;
            }
            else
            {
                errorResponse = new ErrorResponse(HttpStatusCode.InternalServerError.ToString(),
                                                      "An internal server error has occurred.");
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
