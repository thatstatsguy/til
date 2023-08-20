using Microsoft.AspNetCore.Mvc;

namespace PollyWalkthrough.ExponentialBackoffWithJitter;

public static class ExponentialBackoffEndpointsWithJitter
{
    public static WebApplication AddExponentialBackoffWithJitterEndpoints(this WebApplication app)
    {
        app.MapGet("/ExponentialBackoffWithJitter", ([FromServices] IHttpClientFactory clientFactory) =>
        {

        });
            
        return app;
    }
}