using Serilog;
using System.Text;

namespace Test1CA.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, 
                    "Error | Path: {Path} | Query : {Query}| Body: {Body}",
                    httpContext.Request.Path,
                    httpContext.Request.Query,
                    await ReadBody(httpContext.Request));
                
                if(ex.InnerException is not null)
                {
                    _logger.LogError(ex.InnerException.Message,
                        "Inner Exception | Path: {Path} | Query : {Query}| Body: {Body}",
                        httpContext.Request.Path,
                        httpContext.Request.Query,
                        await ReadBody(httpContext.Request));
                }

                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Message= ex.Message, Status = ex.GetType().ToString()
                });

            }
          
        }

        private async Task<string> ReadBody(HttpRequest request)
        {
            request.EnableBuffering(); // IMPORTANT

            using var reader = new StreamReader(
                request.Body,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 1024,
                leaveOpen: true);

            var body = await reader.ReadToEndAsync();

            request.Body.Position = 0;

            return string.IsNullOrWhiteSpace(body) ? "EMPTY" : body;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
