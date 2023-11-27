global using System.Web;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace AscentBackend.Exceptions
{
    public class HttpExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public HttpExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException e)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = e.StatusCode;
                var response = JsonSerializer.Serialize(new { message = e.Message });
                await context.Response.WriteAsync(response);
            }
        }

    }
}
