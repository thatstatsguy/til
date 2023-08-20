using Microsoft.AspNetCore.Mvc;

namespace Polly.RateLimit;

public static class RateLimitEndpoint
{
    public static WebApplication AddRateLimitEndpoints(this WebApplication app)
    {
        app.MapGet("/RateLimit", ([FromServices] IHttpClientFactory clientFactory) =>
        {

        });
            
        return app;
    }
}