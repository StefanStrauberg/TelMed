using Microsoft.AspNetCore.Http;

namespace IdentityServer.Application.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
