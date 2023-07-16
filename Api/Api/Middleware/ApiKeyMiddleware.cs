using System;
namespace Api.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _appKey;
    private const string APIKEY = "x-api-key";

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
	{
        _next = next;
        _appKey = config["ApiKey"];
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (string.IsNullOrWhiteSpace(_appKey))
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Credentials not Configured");
            return;
        }

        if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Credentials were not provided");
            return;
        }

        if (!_appKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await _next(context);
    }
}
