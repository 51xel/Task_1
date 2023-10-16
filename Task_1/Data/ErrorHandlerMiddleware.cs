using System.Net;
using System.Text.Json;

namespace Task_1.Data
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var message = error?.Message;
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case InvalidOperationException:
                        _logger.LogError(error, message);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    default:
                        _logger.LogError(error, message);
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                }

                if (response.StatusCode != (int)HttpStatusCode.InternalServerError)
                {
                    var result = JsonSerializer.Serialize(new { message = message });
                    await response.WriteAsync(result);
                }
            }
        }
    }
}
