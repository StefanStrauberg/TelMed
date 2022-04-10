using IdentityServer.API.Errors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace IdentityServer.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _env.IsDevelopment()
                    ? new ApiException(
                        (int)HttpStatusCode.InternalServerError,
                        ex.Message,
                        ex.StackTrace.ToString())
                    : new ApiResponse((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var json = JsonConvert.SerializeObject(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
